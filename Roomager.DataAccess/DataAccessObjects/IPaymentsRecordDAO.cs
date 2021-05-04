using System;
using System.Collections.Generic;
using System.Text;
using Roomager.Data;

namespace Roomager.DataAccess.DataAccessObjects
{
    public interface IPaymentsRecordDAO
    {
        IEnumerable<PaymentsRecordDTO> GetRecords();
        IEnumerable<PaymentsRecordDTO> GetRecords(int pageSize, int pageNr);
    }
}
