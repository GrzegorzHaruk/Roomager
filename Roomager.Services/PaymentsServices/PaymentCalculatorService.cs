using System;
using System.Collections.Generic;
using System.Text;
using Roomager.Data;

namespace Roomager.Services.PaymentsServices
{
    public class PaymentCalculatorService
    {
        public decimal CalculateTotalCost(decimal energyCost, decimal coldWaterCost, decimal hotWaterCost, decimal gasCost)
        {
            decimal totalCost;

            totalCost = energyCost + coldWaterCost + hotWaterCost + gasCost;

            return totalCost;
        }

        private decimal CalculateCostPerPerson(int tenantsNumber, decimal totalCost)
        {
            decimal costPerPerson = 0m;

            if (tenantsNumber > 0 & totalCost > 0)
            {
                costPerPerson = totalCost / tenantsNumber;
            }

            return costPerPerson;
        }

        public PaymentsRecordDTO GetCalculatedRecord(PaymentsRecordDTO record)
        {
            PaymentsRecordDTO calculatedRecord;

            if (record != null)
            {
                calculatedRecord = new PaymentsRecordDTO
                {
                    RecordId = record.RecordId,
                    EnergyCost = record.EnergyCost,
                    ColdWaterCost = record.ColdWaterCost,
                    HotWaterCost = record.HotWaterCost,
                    GasCost = record.GasCost,
                    NumberOfTenants = record.NumberOfTenants,
                    TotalCost = record.TotalCost,
                    CostPerPerson = record.CostPerPerson,
                    AddDate = record.AddDate,
                    Comment = record.Comment
                };

                // Calculates Total Cost

                calculatedRecord.TotalCost = CalculateTotalCost(
                    calculatedRecord.EnergyCost, 
                    calculatedRecord.ColdWaterCost,
                    calculatedRecord.HotWaterCost,
                    calculatedRecord.GasCost
                    );

                // Calculates Cost Per Person

                if (calculatedRecord.TotalCost > 0 && calculatedRecord.NumberOfTenants > 0)
                {
                    calculatedRecord.CostPerPerson = CalculateCostPerPerson(
                        calculatedRecord.NumberOfTenants,
                        calculatedRecord.TotalCost
                        );
                }

                return calculatedRecord;
            }

            else
            {
                return new PaymentsRecordDTO();
            }
        }
    }
}
