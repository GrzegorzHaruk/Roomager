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

        public PaymentsRecordDTO GetRecord(int id)
        {
            string sql = @"SELECT * FROM PaymentsRecordTable 
                            WHERE RecordId = @id";

            return dataAccess.GetSingleData<PaymentsRecordDTO>(sql, id);
        }

        public int CreateRecord(PaymentsRecordDTO newRecord)
        {
            string sql = @"INSERT INTO PaymentsRecordTable
                            (RecordId, EnergyReading, EnergyUsage, EnergyCost, ColdWaterReading, HotWaterReading, ColdWaterCost, HotWaterCost, GasCost, NumberOfTenants, TotalCost, CostPerPerson, AddDate, Comment)
                                VALUES (@RecordId, @EnergyReading, @EnergyUsage, @EnergyCost, @ColdWaterReading, @HotWaterReading, @ColdWaterCost, @HotWaterCost, @GasCost, @NumberOfTenants, @TotalCost, @CostPerPerson, @AddDate, @Comment)";

            return dataAccess.CreateData<PaymentsRecordDTO>(sql, newRecord);
        }
    }
}