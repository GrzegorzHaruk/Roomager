using System;
using System.Collections.Generic;
using System.Text;
using Roomager.Data;

namespace Roomager.DataAccess.DataAccessObjects
{
    public interface IPaymentsConfigDAO
    {
        PaymentsConfigDTO GetConfig(int id);
        int CreateConfig(PaymentsConfigDTO config);

        //EnergyPaymentsConfigDTO GetEnergyConfig(int id);
        //WaterPaymentsConfigDTO GetWaterConfig(int id);
        //GasPaymentsConfigDTO GetGasConfig(int id);

        //int CreateEnergyConfig(EnergyPaymentsConfigDTO energyConfig);
        //int CreateWaterConfig(WaterPaymentsConfigDTO waterConfig);
        //int CreateGasConfig(GasPaymentsConfigDTO gasConfig);

        //int EditEnergyConfig(int id, EnergyPaymentsConfigDTO energyConfig);
        //int EditWaterConfig(int id, WaterPaymentsConfigDTO energyConfig);
        //int EditGasConfig(int id, GasPaymentsConfigDTO energyConfig);

        //int DeleteEnergyConfig(int id);
        //int DeleteWaterConfig(int id);
        //int DeleteGasConfig(int id);
    }
}
