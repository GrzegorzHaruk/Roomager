using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Roomager.Web.Models.PaymentsModels
{
    public class GasPaymentsConfig
    {
        public int ConfigId { get; set; }

        [Display(Name = "Gas Fee")]
        public decimal GasFee { get; set; }
    }
}
