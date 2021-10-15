using System;
using System.Collections.Generic;
using System.Text;
using Roomager.Data;

namespace Roomager.Services.PaymentsServices
{
    public class PaymentCalculatorService
    {
        public decimal CalculateTotalPayment(decimal energyCost, decimal coldWaterCost, decimal hotWaterCost, decimal gasCost)
        {
            decimal totalPayment;

            totalPayment = energyCost + coldWaterCost + hotWaterCost + gasCost;

            return totalPayment;
        }

        public decimal CalculatePaymentPerPerson(int tenantsNumber, decimal payment)
        {
            decimal paymentPerPerson = 0m;

            if (tenantsNumber > 0 & payment > 0)
            {
                paymentPerPerson = payment / tenantsNumber;
            }

            return paymentPerPerson;
        }
    }
}
