using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Roomager.Data;
using Roomager.Services.PaymentsServices;

namespace Roomager.Tests.PaymentsServicesTests
{
    public class PaymentCalculatorServiceTests
    {
        [Fact]
        public void GetCalculatedRecord_ValidParameter_Success()
        {
            PaymentsRecordDTO record = new PaymentsRecordDTO
            {
                EnergyCost = 100,
                ColdWaterCost = 100,
                HotWaterCost = 100,
                GasCost = 100,
                NumberOfTenants = 4
            };

            PaymentCalculatorService calculatorService = new PaymentCalculatorService();
            PaymentsRecordDTO calculatedRecord = calculatorService.GetCalculatedRecord(record);

            PaymentsRecordDTO expected = new PaymentsRecordDTO
            {
                EnergyCost = 100,
                ColdWaterCost = 100,
                HotWaterCost = 100,
                GasCost = 100,
                NumberOfTenants = 4,
                TotalCost = 400,
                CostPerPerson = 100
            };

            Assert.Equal(expected.TotalCost, calculatedRecord.TotalCost);
            Assert.Equal(expected.CostPerPerson, calculatedRecord.CostPerPerson);
        }

        [Fact]
        public void GetCalculatedRecord_TotalCostNotLargerThan0_Fail()
        {
            PaymentsRecordDTO record = new PaymentsRecordDTO
            {
                EnergyCost = 0,
                ColdWaterCost = 0,
                HotWaterCost = 0,
                GasCost = 0,
                NumberOfTenants = 5
            };

            PaymentCalculatorService calculatorService = new PaymentCalculatorService();
            PaymentsRecordDTO calculatedRecord = calculatorService.GetCalculatedRecord(record);

            PaymentsRecordDTO expected = new PaymentsRecordDTO
            {
                EnergyCost = 0,
                ColdWaterCost = 0,
                HotWaterCost = 0,
                GasCost = 0,
                NumberOfTenants = 5,
                TotalCost = 0
            };

            Assert.Equal(expected.TotalCost, calculatedRecord.TotalCost);
        }

        [Fact]
        public void GetCalculatedRecord_NumberOfTenantsNotLargerThan0_Fail()
        {
            PaymentsRecordDTO record = new PaymentsRecordDTO
            {                
                NumberOfTenants = 0
            };

            PaymentCalculatorService calculatorService = new PaymentCalculatorService();
            PaymentsRecordDTO calculatedRecord = calculatorService.GetCalculatedRecord(record);

            PaymentsRecordDTO expected = new PaymentsRecordDTO
            {
                NumberOfTenants = 0,
                TotalCost = 0,
                CostPerPerson = 0
            };

            Assert.Equal(expected.TotalCost, calculatedRecord.TotalCost);
            Assert.Equal(expected.CostPerPerson, calculatedRecord.CostPerPerson);
        }
    }
}
