using System;
using System.Collections.Generic;
using System.Text;
using Roomager.Data;

namespace Roomager.DataAccess.DataAccessObjects
{
    public interface IPaymentsConfigDAO
    {
        EnergyPaymentConfigDTO GetEnergyConfig(int id);
        WaterPaymentConfigDTO GetWaterConfig(int id);
        GasPaymentConfigDTO GetGasConfig(int id);

        PaymentConfigDTO GetConfig(int id);

        int CreateEnergyConfig(EnergyPaymentConfigDTO energyConfig);
        int CreateWaterConfig(WaterPaymentConfigDTO waterConfig);
        int CreateGasConfig(GasPaymentConfigDTO gasConfig);

        int EditEnergyConfig(int id, EnergyPaymentConfigDTO energyConfig);
        int EditWaterConfig(int id, WaterPaymentConfigDTO energyConfig);
        int EditGasConfig(int id, GasPaymentConfigDTO energyConfig);

        int DeleteEnergyConfig(int id);
        int DeleteWaterConfig(int id);
        int DeleteGasConfig(int id);
    }
}
