using System;
using System.Collections.Generic;
using System.Text;
using Roomager.Data;

namespace Roomager.DataAccess.DataAccessObjects
{
    public class PaymentsRecordDAO : IPaymentsRecordDAO
    {
        IDataAccess dataAccess;

        public PaymentsRecordDAO(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
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
