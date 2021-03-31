using System;

namespace Roomager.Data
{
    public class PaymentConfigDTO : IPaymentConfig
    {
        public int ConfigId { get; set; }
        public DateTime AddTime { get; set; }

        public IEnergyPaymentConfig EnergyPaymentConfig { get; set; }
        public decimal ColdWaterFee { get; set; }
        public decimal HotWaterFee { get; set; }
        public decimal GasFee { get; set; }
        public DateTime AddDate { get; set; }
    }
}
