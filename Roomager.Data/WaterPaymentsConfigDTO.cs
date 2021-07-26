using System;

namespace Roomager.Data
{
    public class WaterPaymentsConfigDTO
    {
        public int ConfigId { get; set; }

        public decimal ColdWaterFee { get; set; }
        public decimal HotWaterFee { get; set; }
    }
}
