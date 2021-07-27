using System;

namespace Roomager.Data
{
    public class PaymentsConfigDTO
    {
        public int Id { get; set; }        

        public EnergyPaymentsConfigDTO EnergyPaymentConfig { get; set; }
        public WaterPaymentsConfigDTO WaterPaymentConfig { get; set; }
        public GasPaymentsConfigDTO GasPaymentConfig { get; set; }
    }
}
