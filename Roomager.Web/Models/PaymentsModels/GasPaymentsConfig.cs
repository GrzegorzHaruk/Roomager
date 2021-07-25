using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomager.Web.Models.PaymentsModels
{
    public class GasPaymentsConfig
    {
        public int ConfigId { get; set; }

        public decimal GasFee { get; set; }
    }
}
