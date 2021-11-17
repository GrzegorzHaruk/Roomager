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
        private IPaymentsRecordDAO paymentsRecordDAO;

        public PaymentsRecordService(IPaymentsRecordDAO paymentsRecordDAO)
        {
            this.paymentsRecordDAO = paymentsRecordDAO;
        }

        public IEnumerable<PaymentsRecordDTO> GetRecordsByYear(int year)
        {
            IEnumerable<PaymentsRecordDTO> records = paymentsRecordDAO.GetRecordsByYear(year);

            if (records == null)
            {
                records = new List<PaymentsRecordDTO>();
            }

            return records;
        }

        public IEnumerable<int> GetRecordYears()
        {
            IEnumerable<int> recordYears = paymentsRecordDAO.GetRecordYears();

            if (recordYears == null)
            {
                recordYears = new List<int>();
            }

            return recordYears;
        }

        public PaymentsRecordDTO GetRecord(int id)
        {
            PaymentsRecordDTO record = paymentsRecordDAO.GetRecord(id);
            if (record == null)
            {
                record = new PaymentsRecordDTO();
            }
            return record;
        }

        public int CreateRecord(PaymentsRecordDTO newRecord)
        {
            int rowsAffected = 0;
            if (newRecord != null)
            {
                rowsAffected = paymentsRecordDAO.CreateRecord(newRecord);
            }
            return rowsAffected;
        }

        public int EditRecord(int id, PaymentsRecordDTO editedRecord)
        {
            int rowsAffected = 0;
            if (editedRecord != null)
            {
                rowsAffected = paymentsRecordDAO.EditRecord(id, editedRecord);
            }
            return rowsAffected;
        }

        public int DeleteRecord(int id)
        {
            int rowsAffected = 0;
            if (id >= 0)
            {
                rowsAffected = paymentsRecordDAO.DeleteRecord(id);
            }                

            return rowsAffected;
        }
    }
}