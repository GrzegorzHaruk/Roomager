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
                <PaymentConfigDTO, EnergyPaymentsConfigDTO, WaterPaymentsConfigDTO, GasPaymentsConfigDTO>
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

        public EnergyPaymentsConfigDTO GetEnergyConfig(int id)
        {
            string sql = "SELECT * FROM EnergyPaymentConfigTable WHERE ConfigId = @id";

            return dataAccess.GetSingleData<EnergyPaymentsConfigDTO>(sql, id);
        }

        public WaterPaymentsConfigDTO GetWaterConfig(int id)
        {
            string sql = "SELECT * FROM WaterPaymentConfigTable WHERE ConfigId = @id";

            return dataAccess.GetSingleData<WaterPaymentsConfigDTO>(sql, id);
        }

        public GasPaymentsConfigDTO GetGasConfig(int id)
        {
            string sql = "SELECT * FROM GasPaymentConfigTable WHERE ConfigId = @id";

            return dataAccess.GetSingleData<GasPaymentsConfigDTO>(sql, id);
        }

        //Create

        public int CreateEnergyConfig(EnergyPaymentsConfigDTO energyConfig)
        {
            string sql = @"INSERT INTO EnergyPaymentConfigTable 
                            (ConfigId, AddDate, SellFee, DistributionFee, CogenerationFee, FixedDistributionFee, FixedTemporaryFee, FixedSubscriptionFee, Tax)
                                VALUES (@ConfigId, @AddDate, @SellFee, @DistributionFee, @CogenerationFee, @FixedDistributionFee, @FixedTemporaryFee, @FixedSubscriptionFee, @Tax)";

            return dataAccess.CreateData<EnergyPaymentsConfigDTO>(sql, energyConfig);            
        }

        public int CreateWaterConfig(WaterPaymentsConfigDTO waterConfig)
        {
            string sql = @"INSERT INTO WaterPaymentConfigTable
                            (ConfigId, AddDate, ColdWaterFee, HotWaterFee)
                                VALUES (@ConfigId, @AddDate, @ColdWaterFee, @HotWaterFee)";

            return dataAccess.CreateData<WaterPaymentsConfigDTO>(sql, waterConfig);            
        }

        public int CreateGasConfig(GasPaymentsConfigDTO gasConfig)
        {
            string sql = @"INSERT INTO GasPaymentConfigTable
                            (ConfigId, AddDate, GasFee)
                                VALUES (@ConfigId, @AddDate, @GasFee)";
            return dataAccess.CreateData<GasPaymentsConfigDTO>(sql, gasConfig);
        }

        //Edit

        public int EditEnergyConfig(int id, EnergyPaymentsConfigDTO energyConfig)
        {
            string sql = @"UPDATE EnergyPaymentConfigTable
                            SET (ConfigId = @ConfigId, AddDate = @AddDate, SellFee = @SellFee, DistributionFee = @DistributionFee, 
                                CogenerationFee = @CogenerationFee, FixedDistributionFee = @FixedDistributionFee, FixedTemporaryFee = @FixedTemporaryFee, 
                                    FixedSubscriptionFee = @FixedSubscriptionFee, Tax = @Tax)
                                        WHERE ConfigId = @id";

            return dataAccess.EditData<EnergyPaymentsConfigDTO>(sql, energyConfig);
        }

        public int EditWaterConfig(int id, WaterPaymentsConfigDTO waterConfig)
        {
            string sql = @"UPDATE WaterPaymentConfigTable
                            SET (ConfigId = @ConfigId, AddDate = @AddDate, ColdWaterFee = @ColdWaterFee, HotWaterFee = @HotWaterFee)
                                WHERE ConfigId = @id";

            return dataAccess.EditData<WaterPaymentsConfigDTO>(sql, waterConfig);
        }

        public int EditGasConfig(int id, GasPaymentsConfigDTO gasConfig)
        {
            string sql = @"UPDATE GasPaymentConfigTable
                            SET (ConfigId = @ConfigId, AddDate = @AddDate, GasFee = @GasFee)
                                WHERE ConfigId = @id";

            return dataAccess.EditData<GasPaymentsConfigDTO>(sql, gasConfig);
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