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

        public PaymentsConfigDTO GetConfig(int id)
        {
            string sql = @"SELECT * FROM PaymentsConfigTable AS PC
                            INNER JOIN EnergyPaymentConfigTable AS EC
                                ON PC.Id = EC.ConfigId
                                    INNER JOIN WaterPaymentConfigTable AS WC
                                        ON PC.Id = WC.ConfigId
                                            INNER JOIN GasPaymentConfigTable AS GC
                                                ON PC.Id = GC.ConfigId
                                                    WHERE PC.Id = @id";

            var test = 

            dataAccess.GetSingleDataJoined
                <PaymentsConfigDTO, EnergyPaymentsConfigDTO, WaterPaymentsConfigDTO, GasPaymentsConfigDTO>
                (sql,
                id,
                (paymentConfig, energyConfig, waterConfig, gasConfig) =>
                {
                    paymentConfig.Id = id;
                    paymentConfig.EnergyPaymentConfig = energyConfig;
                    paymentConfig.WaterPaymentConfig = waterConfig;
                    paymentConfig.GasPaymentConfig = gasConfig;
                    return paymentConfig;
                },
                "ConfigId"
                );

            return test;
        }

        public int CreateConfig(PaymentsConfigDTO config)
        {
            int rowsAffected = 0;

            if (config != null)
            {
                string sql = @"INSERT INTO PaymentsConfigTable 
                                (Id, EnergyConfigId, WaterConfigId, GasConfigId)
                                    VALUES (@Id, @Id, @Id, @Id)";
                rowsAffected = dataAccess.CreateData<PaymentsConfigDTO>(sql, config);
            }

            if (rowsAffected == 1)
            {
                rowsAffected = CreateEnergyConfig(config.EnergyPaymentConfig, config.Id);
            }

            if (rowsAffected == 1)
            {
                rowsAffected = CreateWaterConfig(config.WaterPaymentConfig, config.Id);
            }

            if (rowsAffected == 1)
            {
                rowsAffected = CreateGasConfig(config.GasPaymentConfig, config.Id);
            }

            return rowsAffected;
        }

        public int EditConfig(PaymentsConfigDTO editedConfig)
        {
            int rowsAffected = 0;
            
            if (editedConfig != null)
            {
                rowsAffected = EditEnergyConfig(editedConfig.EnergyPaymentConfig);
            }

            if (rowsAffected == 1)
            {
                rowsAffected = EditWaterConfig(editedConfig.WaterPaymentConfig);
            }

            if (rowsAffected == 1)
            {
                rowsAffected = EditGasConfig(editedConfig.GasPaymentConfig);
            }

            return rowsAffected;
        }

        public int DeleteConfig(int id)
        {
            int rowsAffected = 0;            

            if (id >= 0)
            {
                rowsAffected = DeleteGasConfig(id);
            }

            if (rowsAffected == 1)
            {
                rowsAffected = DeleteWaterConfig(id);
            }

            if (rowsAffected == 1)
            {
                rowsAffected = DeleteEnergyConfig(id);
            }

            if (rowsAffected == 1)
            {
                string sql = @"DELETE FROM PaymentsConfigTable 
                            WHERE Id = @id";

                rowsAffected = dataAccess.DeleteData(sql, id);
            }

            return rowsAffected;
        }

        //Private Create

        private int CreateEnergyConfig(EnergyPaymentsConfigDTO energyConfig, int id)
        {
            energyConfig.ConfigId = id;
            string sql = @"INSERT INTO EnergyPaymentConfigTable
                                (ConfigId, SellFee, DistributionFee, CogenerationFee, FixedDistributionFee, FixedTemporaryFee, FixedSubscriptionFee, Tax)
                                    VALUES (@ConfigId, @SellFee, @DistributionFee, @CogenerationFee, @FixedDistributionFee, @FixedTemporaryFee, @FixedSubscriptionFee, @Tax)";
            
            return dataAccess.CreateData<EnergyPaymentsConfigDTO>(sql, energyConfig);            
        }

        private int CreateWaterConfig(WaterPaymentsConfigDTO waterConfig, int id)
        {
            waterConfig.ConfigId = id;
            string sql = @"INSERT INTO WaterPaymentConfigTable
                                (ConfigId, ColdWaterFee, HotWaterFee)
                                    VALUES (@ConfigId, @ColdWaterFee, @HotWaterFee)";

            return dataAccess.CreateData<WaterPaymentsConfigDTO>(sql, waterConfig);            
        }

        private int CreateGasConfig(GasPaymentsConfigDTO gasConfig, int id)
        {
            gasConfig.ConfigId = id;
            string sql = @"INSERT INTO GasPaymentConfigTable
                                (ConfigId, GasFee)
                                    VALUES (@ConfigId, @GasFee)";

            return dataAccess.CreateData<GasPaymentsConfigDTO>(sql, gasConfig);
        }

        //Private Edit

        private int EditEnergyConfig(EnergyPaymentsConfigDTO energyConfig)
        {
            string sql = @"UPDATE EnergyPaymentConfigTable
                            SET ConfigId = @ConfigId, SellFee = @SellFee, DistributionFee = @DistributionFee, 
                                CogenerationFee = @CogenerationFee, FixedDistributionFee = @FixedDistributionFee, FixedTemporaryFee = @FixedTemporaryFee, 
                                    FixedSubscriptionFee = @FixedSubscriptionFee, Tax = @Tax
                                        WHERE ConfigId = @ConfigId";

            return dataAccess.EditData<EnergyPaymentsConfigDTO>(sql, energyConfig);
        }

        public int EditWaterConfig(WaterPaymentsConfigDTO waterConfig)
        {
            string sql = @"UPDATE WaterPaymentConfigTable
                            SET ConfigId = @ConfigId, ColdWaterFee = @ColdWaterFee, HotWaterFee = @HotWaterFee
                                WHERE ConfigId = @ConfigId";

            return dataAccess.EditData<WaterPaymentsConfigDTO>(sql, waterConfig);
        }

        public int EditGasConfig(GasPaymentsConfigDTO gasConfig)
        {
            string sql = @"UPDATE GasPaymentConfigTable
                            SET ConfigId = @ConfigId, GasFee = @GasFee
                                WHERE ConfigId = @ConfigId";

            return dataAccess.EditData<GasPaymentsConfigDTO>(sql, gasConfig);
        }

        //Private Delete

        public int DeleteEnergyConfig(int id)
        {
            string sql = @"DELETE FROM EnergyPaymentConfigTable 
                            WHERE ConfigId = @id";

            return dataAccess.DeleteData(sql, id);
        }

        public int DeleteWaterConfig(int id)
        {
            string sql = @"DELETE FROM WaterPaymentConfigTable 
                            WHERE ConfigId = @id";

            return dataAccess.DeleteData(sql, id);
        }

        public int DeleteGasConfig(int id)
        {
            string sql = @"DELETE FROM GasPaymentConfigTable 
                            WHERE ConfigId = @id";

            return dataAccess.DeleteData(sql, id);
        }
    }
}