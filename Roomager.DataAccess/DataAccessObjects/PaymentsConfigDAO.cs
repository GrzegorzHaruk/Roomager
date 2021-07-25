using Roomager.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roomager.DataAccess.DataAccessObjects
{
    public class PaymentsConfigDAO : IPaymentsConfigDAO
    {
        IDataAccess dataAccess;

        public PaymentsConfigDAO(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        //Get

        public PaymentConfigDTO GetConfig(int id)
        {
            string sql = @"SELECT * FROM PaymentsConfigTable AS PC
                            INNER JOIN EnergyPaymentConfigTable AS EC
                                ON PC.Id = EC.ConfigId
                                    INNER JOIN WaterPaymentConfigTable AS WC
                                        ON PC.Id = WC.ConfigId
                                            INNER JOIN GasPaymentConfigTable AS GC
                                                ON PC.Id = GC.ConfigId
                                                    WHERE PC.Id = @id";

            return dataAccess.GetSingleDataJoined
                <PaymentConfigDTO, EnergyPaymentConfigDTO, WaterPaymentConfigDTO, GasPaymentConfigDTO>
                (sql,
                id,
                (paymentConfig, energyConfig, waterConfig, gasConfig) =>
                {
                    paymentConfig.ConfigId = id;
                    paymentConfig.EnergyPaymentConfig = energyConfig;
                    paymentConfig.WaterPaymentConfig = waterConfig;
                    paymentConfig.GasPaymentConfig = gasConfig;
                    return paymentConfig;
                },
                "ConfigId"
                );
        }

        public EnergyPaymentConfigDTO GetEnergyConfig(int id)
        {
            string sql = "SELECT * FROM EnergyPaymentConfigTable WHERE ConfigId = @id";

            return dataAccess.GetSingleData<EnergyPaymentConfigDTO>(sql, id);
        }

        public WaterPaymentConfigDTO GetWaterConfig(int id)
        {
            string sql = "SELECT * FROM WaterPaymentConfigTable WHERE ConfigId = @id";

            return dataAccess.GetSingleData<WaterPaymentConfigDTO>(sql, id);
        }

        public GasPaymentConfigDTO GetGasConfig(int id)
        {
            string sql = "SELECT * FROM GasPaymentConfigTable WHERE ConfigId = @id";

            return dataAccess.GetSingleData<GasPaymentConfigDTO>(sql, id);
        }

        //Create

        public int CreateEnergyConfig(EnergyPaymentConfigDTO energyConfig)
        {
            string sql = @"INSERT INTO EnergyPaymentConfigTable 
                            (ConfigId, AddDate, SellFee, DistributionFee, CogenerationFee, FixedDistributionFee, FixedTemporaryFee, FixedSubscriptionFee, Tax)
                                VALUES (@ConfigId, @AddDate, @SellFee, @DistributionFee, @CogenerationFee, @FixedDistributionFee, @FixedTemporaryFee, @FixedSubscriptionFee, @Tax)";

            return dataAccess.CreateData<EnergyPaymentConfigDTO>(sql, energyConfig);            
        }

        public int CreateWaterConfig(WaterPaymentConfigDTO waterConfig)
        {
            string sql = @"INSERT INTO WaterPaymentConfigTable
                            (ConfigId, AddDate, ColdWaterFee, HotWaterFee)
                                VALUES (@ConfigId, @AddDate, @ColdWaterFee, @HotWaterFee)";

            return dataAccess.CreateData<WaterPaymentConfigDTO>(sql, waterConfig);            
        }

        public int CreateGasConfig(GasPaymentConfigDTO gasConfig)
        {
            string sql = @"INSERT INTO GasPaymentConfigTable
                            (ConfigId, AddDate, GasFee)
                                VALUES (@ConfigId, @AddDate, @GasFee)";
            return dataAccess.CreateData<GasPaymentConfigDTO>(sql, gasConfig);
        }

        //Edit

        public int EditEnergyConfig(int id, EnergyPaymentConfigDTO energyConfig)
        {
            string sql = @"UPDATE EnergyPaymentConfigTable
                            SET (ConfigId = @ConfigId, AddDate = @AddDate, SellFee = @SellFee, DistributionFee = @DistributionFee, 
                                CogenerationFee = @CogenerationFee, FixedDistributionFee = @FixedDistributionFee, FixedTemporaryFee = @FixedTemporaryFee, 
                                    FixedSubscriptionFee = @FixedSubscriptionFee, Tax = @Tax)
                                        WHERE ConfigId = @id";

            return dataAccess.EditData<EnergyPaymentConfigDTO>(sql, energyConfig);
        }

        public int EditWaterConfig(int id, WaterPaymentConfigDTO waterConfig)
        {
            string sql = @"UPDATE WaterPaymentConfigTable
                            SET (ConfigId = @ConfigId, AddDate = @AddDate, ColdWaterFee = @ColdWaterFee, HotWaterFee = @HotWaterFee)
                                WHERE ConfigId = @id";

            return dataAccess.EditData<WaterPaymentConfigDTO>(sql, waterConfig);
        }

        public int EditGasConfig(int id, GasPaymentConfigDTO gasConfig)
        {
            string sql = @"UPDATE GasPaymentConfigTable
                            SET (ConfigId = @ConfigId, AddDate = @AddDate, GasFee = @GasFee)
                                WHERE ConfigId = @id";

            return dataAccess.EditData<GasPaymentConfigDTO>(sql, gasConfig);
        }

        //Delete

        public int DeleteEnergyConfig(int id)
        {
            string sql = @"DELETE FROM EnergyPaymentConfigTable WHERE ConfigId = @id";

            return dataAccess.DeleteData(sql, id);
        }

        public int DeleteWaterConfig(int id)
        {
            string sql = @"DELETE FROM WaterPaymentConfigTable WHERE ConfigId = @id";

            return dataAccess.DeleteData(sql, id);
        }

        public int DeleteGasConfig(int id)
        {
            string sql = @"DELETE FROM GasPaymentConfigTable WHERE ConfigId = @id";

            return dataAccess.DeleteData(sql, id);
        }
    }
}