using System;
using System.Collections.Generic;
using System.Text;
using Roomager.Data;

namespace Roomager.DataAccess.DataAccessObjects
{
    public interface IPaymentsRecordDAO
    {
        IEnumerable<PaymentsRecordDTO> GetRecordsByYear(int year);
        IEnumerable<int> GetRecordYears();
        PaymentsRecordDTO GetRecord(int id);
        int CreateRecord(PaymentsRecordDTO newRecord);
        int EditRecord(int id, PaymentsRecordDTO editedRecord);
        int DeleteRecord(int id);
    }
}
