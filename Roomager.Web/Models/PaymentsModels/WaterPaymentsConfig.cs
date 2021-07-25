using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomager.Web.Models.PaymentsModels
{
    public class WaterPaymentsConfig
    {
        public int ConfigId { get; set; }

        public decimal ColdWaterFee { get; set; }
        public decimal HotWaterFee { get; set; }
    }
}
