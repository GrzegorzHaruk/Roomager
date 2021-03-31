using System;

namespace Roomager.Data
{
    public interface IEnergyPaymentConfig
    {
        int ConfigId { get; set; }
        DateTime AddDate { get; set; }        

        decimal SellFee { get; set; }
        decimal DistributionFee { get; set; }
        decimal CogenerationFee { get; set; }
        decimal FixedDistributionFee { get; set; }
        decimal FixedTemporaryFee { get; set; }
        decimal FixedSubscriptionFee { get; set; }
        decimal Tax { get; set; }
    }
}
