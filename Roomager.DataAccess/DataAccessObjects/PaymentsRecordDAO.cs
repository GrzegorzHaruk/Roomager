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

        public IEnumerable<PaymentsRecordDTO> GetRecordsByYear(int year)
        {
            string sql = @"SELECT * FROM PaymentsRecordTable
                            WHERE year(AddDate) = @year";

            return dataAccess.GetDataByYear<PaymentsRecordDTO>(sql, year);
        }

        public IEnumerable<int> GetRecordYears()
        {
            string sql = @"SELECT DISTINCT year(AddDate) AS Year
                            FROM PaymentsRecordTable
                                ORDER BY Year ASC";

            return dataAccess.GetData<int>(sql);
        }

        public PaymentsRecordDTO GetRecord(int id)
        {
            string sql = @"SELECT * FROM PaymentsRecordTable 
                            WHERE RecordId = @id";

            return dataAccess.GetSingleData<PaymentsRecordDTO>(sql, id);
        }

        public int CreateRecord(PaymentsRecordDTO newRecord)
        {
            string sql = @"INSERT INTO PaymentsRecordTable
                            (EnergyCost, ColdWaterCost, HotWaterCost, GasCost, NumberOfTenants, TotalCost, CostPerPerson, AddDate, Comment)
                                VALUES (@EnergyCost, @ColdWaterCost, @HotWaterCost, @GasCost, @NumberOfTenants, @TotalCost, @CostPerPerson, @AddDate, @Comment)";

            return dataAccess.CreateData<PaymentsRecordDTO>(sql, newRecord);
        }

        public int EditRecord(int id, PaymentsRecordDTO editedRecord)
        {
            string sql = @"UPDATE PaymentsRecordTable
                            SET EnergyCost = @EnergyCost, ColdWaterCost = @ColdWaterCost, HotWaterCost = @HotWaterCost, 
                                    GasCost = @GasCost, NumberOfTenants = @NumberOfTenants, TotalCost = @TotalCost, 
                                        CostPerPerson = @CostPerPerson, AddDate = @AddDate, Comment = @Comment
                                            WHERE RecordId = @RecordId";

            return dataAccess.EditData<PaymentsRecordDTO>(sql, editedRecord);
        }

        public int DeleteRecord(int id)
        {
            string sql = @"DELETE FROM PaymentsRecordTable WHERE RecordId = @id";

            return dataAccess.DeleteData(sql, id);
        }
    }
}