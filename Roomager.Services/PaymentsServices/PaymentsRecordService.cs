using Roomager.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Roomager.DataAccess.DataAccessObjects;

namespace Roomager.Services.PaymentsServices
{
    public class PaymentsRecordService : IPaymentsRecordService
    {
        IPaymentsRecordDAO paymentsRecordAccess;

        public PaymentsRecordService(IPaymentsRecordDAO paymentsRecordAccess)
        {
            this.paymentsRecordAccess = paymentsRecordAccess;
        }

        public IEnumerable<PaymentsRecordDTO> GetRecords()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PaymentsRecordDTO> GetRecords(int pageSize, int pageNr)
        {
            throw new NotImplementedException();
        }
    }
}
