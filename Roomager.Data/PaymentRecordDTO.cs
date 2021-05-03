using System;
using System.Collections.Generic;
using System.Text;

namespace Roomager.Data
{
    public class PaymentsRecordDTO : IPaymentRecord
    {
        public int RecordId { get; set; }

        public double EnergyReading { get; set; }
        public double EnergyUsage { get; set; }
        public decimal EnergyCost { get; set; }

        public double ColdWaterReading { get; set; }
        public decimal ColdWaterCost { get; set; }
        public double HotWaterReading { get; set; }
        public decimal HotWaterCost { get; set; }

        public decimal GasCost { get; set; }

        public int NumberOfTenants { get; set; }

        public decimal TotalCost { get; set; }
        public decimal CostPerPerson { get; set; }

        public DateTime AddDate { get; set; }

        public string Comment { get; set; }
    }
}
