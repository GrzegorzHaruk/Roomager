using Roomager.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Roomager.DataAccess.DataAccessObjects;
using System.Linq;

namespace Roomager.Services.PaymentsServices
{
    public class PaymentsRecordService : IPaymentsRecordService
    {
        IPaymentsRecordDAO paymentsRecordDAO;

        public PaymentsRecordService(IPaymentsRecordDAO paymentsRecordDAO)
        {
            this.paymentsRecordDAO = paymentsRecordDAO;
        }

        public IEnumerable<PaymentsRecordDTO> GetRecords()
        {
            IEnumerable<PaymentsRecordDTO> records = paymentsRecordDAO.GetRecords();

            if (records == null)
            {
                records = new List<PaymentsRecordDTO>();
            }

            return records;
        }

        public IEnumerable<PaymentsRecordDTO> GetRecords(int pageSize, int pageNr)
        {
            IEnumerable<PaymentsRecordDTO> records = paymentsRecordDAO.GetRecords(pageSize, pageNr);

            if (records == null)
            {
                records = new List<PaymentsRecordDTO>();
            }

            return records;
        }
    }
}