using System;

namespace Roomager.Web.Models.PaymentsModels
{
    public class PaymentsConfig
    {
        public int Id { get; set; }        

        public EnergyPaymentsConfig EnergyPaymentConfig { get; set; }
        public WaterPaymentsConfig WaterPaymentsConfig { get; set; }
        public GasPaymentsConfig GasPaymentsConfig { get; set; }
    }
}
