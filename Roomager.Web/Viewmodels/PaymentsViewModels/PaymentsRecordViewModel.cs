using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Roomager.Web.Models.PaymentsModels;

namespace Roomager.Web.Viewmodels.PaymentsViewModels
{
    public class PaymentsRecordViewModel
    {
        public PaymentsRecordViewModel(PaymentsRecord PaymentsRecord)
        {
            this.PaymentsRecord = PaymentsRecord;
        }

        public PaymentsRecordViewModel()
        {

        }

        public PaymentsRecord PaymentsRecord { get; set; }
    }
}
