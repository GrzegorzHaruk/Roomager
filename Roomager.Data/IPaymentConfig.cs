using System;

namespace Roomager.Data
{
    public interface IPaymentConfig
    {
        int ConfigId { get; set; }
        DateTime AddTime { get; set; }

        IEnergyPaymentConfig EnergyPaymentConfig { get; set; }
        decimal ColdWaterFee { get; set; }
        decimal HotWaterFee { get; set; }
        decimal GasFee { get; set; }
        DateTime AddDate { get; set; }        
    }
}
