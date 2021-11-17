using System;
using System.Collections.Generic;
using Xunit;
using Roomager.Services.PaymentsServices;
using Autofac.Extras.Moq;
using Roomager.DataAccess.DataAccessObjects;
using Roomager.Data;
using System.Linq;
using Moq;

namespace Roomager.Tests.PaymentsServicesTests
{
    public class PaymentsRecordServiceTests
    {
        [Fact]
        public void GetRecordsByYear_Success()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IPaymentsRecordDAO>()
                    .Setup(x => x.GetRecordsByYear(2018))
                    .Returns(sampleRecords.Where(x => x.AddDate.Year == 2018));

                var service = mock.Create<PaymentsRecordService>();

                var expected = sampleRecords.Where(x => x.AddDate.Year == 2018).ToList();

                var actual = service.GetRecordsByYear(2018).ToList();

                Assert.True(actual.Count == 1);
                Assert.True(expected.Count == actual.Count);
            }
        }

        [Fact]
        public void GetRecordsByYear_Fail_GetNewEmptyRecord()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IPaymentsRecordDAO>()
                    .Setup(x => x.GetRecordsByYear(2018))
                    .Returns(sampleRecords.Where(x => x.AddDate.Year == 2018));

                var service = mock.Create<PaymentsRecordService>();

                var expected = sampleRecords.Where(x => x.AddDate.Year == 2025).ToList();

                var actual = service.GetRecordsByYear(2025).ToList();

                Assert.True(actual.Count == 0);
            }
        }

        [Fact]
        public void GetRecord_Success()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IPaymentsRecordDAO>()
                    .Setup(x => x.GetRecord(1))
                    .Returns(sampleRecords.Where(x => x.RecordId == 1).SingleOrDefault());

                var service = mock.Create<PaymentsRecordService>();
                var expected = sampleRecords.Where(x => x.RecordId == 1).SingleOrDefault();
                var actual = service.GetRecord(1);

                Assert.True(actual.RecordId == expected.RecordId);
            }
        }

        [Fact]
        public void GetRecord_NoResult_GetNewObject()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IPaymentsRecordDAO>()
                    .Setup(x => x.GetRecord(15))
                    .Returns(new PaymentsRecordDTO());

                var service = mock.Create<PaymentsRecordService>();
                var expected = new PaymentsRecordDTO();
                var actual = service.GetRecord(15);

                Assert.True(actual.RecordId == expected.RecordId);                
            }
        }

        [Fact]
        public void CreateRecord_RecordCreated_Returns1()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var newRecord = new PaymentsRecordDTO
                {
                    RecordId = 100,
                    EnergyReading = 555,
                    EnergyUsage = 666,
                    EnergyCost = 888,
                    HotWaterReading = 111,
                    ColdWaterReading = 111,
                    ColdWaterCost = 100,
                    HotWaterCost = 100,
                    GasCost = 100,
                    NumberOfTenants = 5,
                    TotalCost = 500,
                    CostPerPerson = 100,
                    AddDate = DateTime.Now,
                    Comment = ""
                };

                mock.Mock<IPaymentsRecordDAO>()
                    .Setup(x => x.CreateRecord(newRecord))
                    .Returns(1);

                var service = mock.Create<PaymentsRecordService>();

                var result = service.CreateRecord(newRecord);

                Assert.True(result == 1);                
            }
        }

        [Fact]
        public void CreateRecord_InputNullObject_Returns0()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IPaymentsRecordDAO>()
                    .Setup(x => x.CreateRecord(null))
                    .Returns(0);

                var service = mock.Create<PaymentsRecordService>();

                var result = service.CreateRecord(null);

                Assert.True(result == 0);
            }
        }

        [Fact]
        public void CreateRecord_InputInvalidObject_Returns0()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var newRecord = GetInvalidSampleRecord();

                mock.Mock<IPaymentsRecordDAO>()
                    .Setup(x => x.CreateRecord(newRecord))
                    .Returns(0);

                var service = mock.Create<PaymentsRecordService>();

                var result = service.CreateRecord(newRecord);

                Assert.True(result == 0);
            }
        }

        [Fact]
        public void EditRecord_ValidInput_Success()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var record = sampleRecords.FirstOrDefault();

                mock.Mock<IPaymentsRecordDAO>()
                    .Setup(x => x.EditRecord(record.RecordId, record))
                    .Returns(1);

                var service = mock.Create<PaymentsRecordService>();

                var result = service.EditRecord(record.RecordId, record);

                mock.Mock<IPaymentsRecordDAO>()
                    .Verify(x => x.EditRecord(record.RecordId, record), Times.Once());
                    
                Assert.True(result == 1);
            }
        }

        [Fact]
        public void EditRecord_InvalidInput_Returs0()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var record = GetInvalidSampleRecord();

                mock.Mock<IPaymentsRecordDAO>()
                    .Setup(x => x.EditRecord(record.RecordId, record))
                    .Returns(0);

                var service = mock.Create<PaymentsRecordService>();

                var result = service.EditRecord(record.RecordId, record);

                mock.Mock<IPaymentsRecordDAO>()
                    .Verify(x => x.EditRecord(record.RecordId, record), Times.Once());

                Assert.True(result == 0);
            }
        }

        [Fact]
        public void DeleteRecord_Success()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IPaymentsRecordDAO>()
                    .Setup(x => x.DeleteRecord(1))
                    .Returns(1);

                var service = mock.Create<PaymentsRecordService>();

                var result = service.DeleteRecord(1);

                mock.Mock<IPaymentsRecordDAO>()
                    .Verify(x => x.DeleteRecord(1), Times.Once());

                Assert.True(result == 1);
            }
        }

        [Fact]
        public void GetRecordYears_Success()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IPaymentsRecordDAO>()
                    .Setup(x => x.GetRecordYears())
                    .Returns(new List<int> {2015,2016,2017,2018});

                var service = mock.Create<PaymentsRecordService>();

                var expected = new List<int> { 2015, 2016, 2017, 2018 };

                var actual = service.GetRecordYears().ToList();

                Assert.True(expected.Count == actual.Count);

                for (int i = 0; i < expected.Count; i++)
                {
                    Assert.True(expected[i] == actual[i]);
                }
            }
        }

        private IEnumerable<PaymentsRecordDTO> sampleRecords = new List<PaymentsRecordDTO>
            {
                new PaymentsRecordDTO
                {
                    RecordId = 1, EnergyReading = 0, EnergyUsage = 0, EnergyCost = 0, ColdWaterReading = 0, ColdWaterCost = 0, HotWaterReading = 0, HotWaterCost = 0, GasCost = 0, NumberOfTenants = 0, TotalCost = 0, CostPerPerson = 0, AddDate = new DateTime(2015,01,01), Comment = ""
                },
                new PaymentsRecordDTO
                {
                    RecordId = 2, EnergyReading = 15, EnergyUsage = 15, EnergyCost = 30, ColdWaterReading = 0, ColdWaterCost = 0, HotWaterReading = 0, HotWaterCost = 0, GasCost = 0, NumberOfTenants = 0, TotalCost = 0, CostPerPerson = 0, AddDate = new DateTime(2016,01,01), Comment = ""
                },
                new PaymentsRecordDTO
                {
                    RecordId = 3, EnergyReading = 32, EnergyUsage = 12, EnergyCost = 32, ColdWaterReading = 0, ColdWaterCost = 0, HotWaterReading = 0, HotWaterCost = 0, GasCost = 0, NumberOfTenants = 0, TotalCost = 0, CostPerPerson = 0, AddDate = new DateTime(2017,01,01), Comment = ""
                },
                new PaymentsRecordDTO
                {
                    RecordId = 4, EnergyReading = 49, EnergyUsage = 13, EnergyCost = 35, ColdWaterReading = 0, ColdWaterCost = 0, HotWaterReading = 0, HotWaterCost = 0, GasCost = 0, NumberOfTenants = 0, TotalCost = 0, CostPerPerson = 0, AddDate = new DateTime(2018,01,01), Comment = ""
                },
                new PaymentsRecordDTO
                {
                    RecordId = 5, EnergyReading = 65, EnergyUsage = 17, EnergyCost = 37, ColdWaterReading = 0, ColdWaterCost = 0, HotWaterReading = 0, HotWaterCost = 0, GasCost = 0, NumberOfTenants = 0, TotalCost = 0, CostPerPerson = 0, AddDate = new DateTime(2019,01,01), Comment = ""
                },
            };

        private PaymentsRecordDTO GetInvalidSampleRecord()
        {
            PaymentsRecordDTO record = new PaymentsRecordDTO
            {
                RecordId = 100,
            };

            return record;
        }
    }
}