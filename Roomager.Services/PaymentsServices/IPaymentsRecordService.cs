using System;
using System.Collections.Generic;
using System.Text;
using Roomager.Data;

namespace Roomager.Services.PaymentsServices
{
    public interface IPaymentsRecordService
    {
        IEnumerable<PaymentsRecordDTO> GetRecords();
        IEnumerable<PaymentsRecordDTO> GetRecords(int pageSize, int pageNr);
        PaymentsRecordDTO GetRecord(int id);
    }
}
