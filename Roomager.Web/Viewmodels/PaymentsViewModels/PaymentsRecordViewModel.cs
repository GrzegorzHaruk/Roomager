using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Roomager.Services.PaymentsServices;
using Roomager.Web.Models.PaymentsModels;

namespace Roomager.Web.Viewmodels.PaymentsViewModels
{
    public class PaymentsRecordViewModel
    {
        public IEnumerable<PaymentsRecord> Records { get; set; }

        public PaymentsRecordPagingInfo PagingInfo { get; set; }
    }
}
