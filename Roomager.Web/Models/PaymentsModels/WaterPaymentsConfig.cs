using System;
using System.ComponentModel.DataAnnotations;

namespace Roomager.Web.Models.PaymentsModels
{
    public class WaterPaymentsConfig
    {
        public int ConfigId { get; set; }

        [Display(Name = "Cold Water Fee")]
        public decimal ColdWaterFee { get; set; }

        [Display(Name = "Hot Water Fee")]
        public decimal HotWaterFee { get; set; }
    }
}
