using System;

namespace Roomager.Data
{
    public class EnergyPaymentsConfigDTO
    {
        public int ConfigId { get; set; }    

        public decimal SellFee { get; set; }
        public decimal DistributionFee { get; set; }
        public decimal CogenerationFee { get; set; }
        public decimal FixedDistributionFee { get; set; }
        public decimal FixedTemporaryFee { get; set; }
        public decimal FixedSubscriptionFee { get; set; }
        public decimal Tax { get; set; }
    }
}
