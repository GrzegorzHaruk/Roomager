using System;

namespace Roomager.Data
{
    public class PaymentConfigDTO
    {
        public int ConfigId { get; set; }        

        public EnergyPaymentsConfigDTO EnergyPaymentConfig { get; set; }
        public WaterPaymentsConfigDTO WaterPaymentConfig { get; set; }
        public GasPaymentsConfigDTO GasPaymentConfig { get; set; }
    }
}
