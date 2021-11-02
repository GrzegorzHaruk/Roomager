using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Roomager.Web.Models.PaymentsModels;

namespace Roomager.Web.Viewmodels.PaymentsViewModels
{
    public class PaymentsRecordViewModel
    {
        public PaymentsRecordViewModel()
        {
            // Temporary fake years list 
            PagingYears = new List<int> { 2016, 2017, 2018, 2019, 2020, 2021 };
        }

        public List<int> PagingYears { get; set; }

        public IEnumerable<PaymentsRecord> Records { get; set; }
    }
}
