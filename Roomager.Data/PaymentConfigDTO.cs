using System;

namespace Roomager.Data
{
    public class PaymentConfigDTO
    {
        public int ConfigId { get; set; }        

        public EnergyPaymentConfigDTO EnergyPaymentConfig { get; set; }
        public WaterPaymentConfigDTO WaterPaymentConfig { get; set; }
        public GasPaymentConfigDTO GasPaymentConfig { get; set; }
    }
}
