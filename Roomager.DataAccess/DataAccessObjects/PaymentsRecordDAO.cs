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
            string sql = "SELECT * FROM PaymentsRecordTable";

            return dataAccess.GetData<PaymentsRecordDTO>(sql);
        }

        public IEnumerable<PaymentsRecordDTO> GetRecords(int pageSize, int pageNr)
        {
            string sql = @"SELECT * FROM PaymentsRecordTable AS PRT
                            ORDER BY PRT.AddDate ASC
                                OFFSET @pageSize * (@pageNr - 1) ROWS
                                    FETCH NEXT @pageSize ROWS ONLY";

            return dataAccess.GetData<PaymentsRecordDTO>(sql, pageSize, pageNr);
        }
    }
}