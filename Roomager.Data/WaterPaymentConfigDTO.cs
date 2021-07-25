using System;
using System.Collections.Generic;
using System.Text;

namespace Roomager.Data
{
    public class WaterPaymentConfigDTO
    {
        public int ConfigId { get; set; }

        public decimal ColdWaterFee { get; set; }
        public decimal HotWaterFee { get; set; }
    }
}
