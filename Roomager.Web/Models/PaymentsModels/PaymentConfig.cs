using System;

namespace Roomager.Web.Models.PaymentsModels
{
    public class PaymentConfig
    {
        public int ConfigId { get; set; }
        public DateTime AddTime { get; set; }

        public EnergyPaymentConfig EnergyPaymentConfig { get; set; }
        public decimal ColdWaterFee { get; set; }
        public decimal HotWaterFee { get; set; }
        public decimal GasFee { get; set; }
        public DateTime AddDate { get; set; }
    }
}
