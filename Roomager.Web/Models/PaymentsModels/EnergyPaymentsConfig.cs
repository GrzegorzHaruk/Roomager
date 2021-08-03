using System;
using System.ComponentModel.DataAnnotations;

namespace Roomager.Web.Models.PaymentsModels
{
    public class EnergyPaymentsConfig
    {
        public int ConfigId { get; set; }        

        [Display(Name = "Sell Fee")]
        public decimal SellFee { get; set; }

        [Display(Name = "Distribution Fee")]
        public decimal DistributionFee { get; set; }

        [Display(Name = "Cogeneration Fee")]
        public decimal CogenerationFee { get; set; }

        [Display(Name = "Fixed Distribution Fee")]
        public decimal FixedDistributionFee { get; set; }

        [Display(Name = "Fixed Temporary Fee")]
        public decimal FixedTemporaryFee { get; set; }

        [Display(Name = "Fixed Subscription Fee")]
        public decimal FixedSubscriptionFee { get; set; }

        [Display(Name = "Tax")]
        public decimal Tax { get; set; }
    }
}
