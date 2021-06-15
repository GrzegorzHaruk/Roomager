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
        public void GetRecords_GetAllRecords_Success()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IPaymentsRecordDAO>()
                    .Setup(x => x.GetRecords())
                    .Returns(GetSampleRecords());

                var service = mock.Create<PaymentsRecordService>();

                var expected = GetSampleRecords().ToList();

                var actual = service.GetRecords().ToList();

                Assert.True(actual != null);

                Assert.Equal(expected.Count, actual.Count);

                for (int i = 0; i < expected.Count; i++)
                {
                    Assert.Equal(expected[i].RecordId, actual[i].RecordId);
                }
            }
        }

        [Fact]
        public void GetRecords_GetAllRecords_GetEmptyList()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IPaymentsRecordDAO>()
                    .Setup(x => x.GetRecords())
                    .Returns(new List<PaymentsRecordDTO>());

                var service = mock.Create<PaymentsRecordService>();

                var expected = new List<PaymentsRecordDTO>();
                var actual = service.GetRecords().ToList();

                Assert.Equal(expected.Count, actual.Count);
                Assert.True(actual.Count == 0);
            }        
        }

        [Theory]
        [InlineData(1,2)]
        [InlineData(2,2)]
        [InlineData(3,2)]
        [InlineData(1,5)]
        [InlineData(2,5)]
        [InlineData(2,6)]
        public void GetRecords_GetRecordsPaged_Success(int pageNr, int pageSize)
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IPaymentsRecordDAO>()
                    .Setup(x => x.GetRecords(pageSize, pageNr))
                    .Returns(GetSampleRecords(pageSize, pageNr));

                var service = mock.Create<PaymentsRecordService>();

                var expected = GetSampleRecords(pageSize, pageNr).ToList();

                var actual = service.GetRecords(pageSize, pageNr).ToList();

                Assert.Equal(expected.Count, actual.Count);

                for (int i = 0; i < expected.Count; i++)
                {
                    Assert.Equal(expected[i].RecordId, actual[i].RecordId);
                }
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
                var newRecord = GetSampleRecord();

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

        private IEnumerable<PaymentsRecordDTO> sampleRecords = new List<PaymentsRecordDTO>
            {
                new PaymentsRecordDTO
                {
                    RecordId = 1, EnergyReading = 0, EnergyUsage = 0, EnergyCost = 0, ColdWaterReading = 0, ColdWaterCost = 0, HotWaterReading = 0, HotWaterCost = 0, GasCost = 0, NumberOfTenants = 0, TotalCost = 0, CostPerPerson = 0, AddDate = DateTime.Now, Comment = ""
                },
                new PaymentsRecordDTO
                {
                    RecordId = 2, EnergyReading = 15, EnergyUsage = 15, EnergyCost = 30, ColdWaterReading = 0, ColdWaterCost = 0, HotWaterReading = 0, HotWaterCost = 0, GasCost = 0, NumberOfTenants = 0, TotalCost = 0, CostPerPerson = 0, AddDate = DateTime.Now, Comment = ""
                },
                new PaymentsRecordDTO
                {
                    RecordId = 3, EnergyReading = 32, EnergyUsage = 12, EnergyCost = 32, ColdWaterReading = 0, ColdWaterCost = 0, HotWaterReading = 0, HotWaterCost = 0, GasCost = 0, NumberOfTenants = 0, TotalCost = 0, CostPerPerson = 0, AddDate = DateTime.Now, Comment = ""
                },
                new PaymentsRecordDTO
                {
                    RecordId = 4, EnergyReading = 49, EnergyUsage = 13, EnergyCost = 35, ColdWaterReading = 0, ColdWaterCost = 0, HotWaterReading = 0, HotWaterCost = 0, GasCost = 0, NumberOfTenants = 0, TotalCost = 0, CostPerPerson = 0, AddDate = DateTime.Now, Comment = ""
                },
                new PaymentsRecordDTO
                {
                    RecordId = 5, EnergyReading = 65, EnergyUsage = 17, EnergyCost = 37, ColdWaterReading = 0, ColdWaterCost = 0, HotWaterReading = 0, HotWaterCost = 0, GasCost = 0, NumberOfTenants = 0, TotalCost = 0, CostPerPerson = 0, AddDate = DateTime.Now, Comment = ""
                },
            };

        private IEnumerable<PaymentsRecordDTO> GetSampleRecords()
        {
            return sampleRecords;
        }

        private IEnumerable<PaymentsRecordDTO> GetSampleRecords(int pageSize, int pageNr)
        {
            return sampleRecords.Skip((pageNr - 1) * pageSize).Take(pageSize);
        }

        private PaymentsRecordDTO GetSampleRecord()
        {
            PaymentsRecordDTO record = new PaymentsRecordDTO
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

            return record;
        }

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