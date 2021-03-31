using System;

namespace Roomager.Data
{
    public interface IPaymentRecord
    {
        DateTime AddDate { get; set; }
        decimal ColdWaterCost { get; set; }
        double ColdWaterReading { get; set; }
        string Comment { get; set; }
        decimal CostPerPerson { get; set; }
        decimal EnergyCost { get; set; }
        double EnergyReading { get; set; }
        double EnergyUsage { get; set; }
        decimal GasCost { get; set; }
        decimal HotWaterCost { get; set; }
        double HotWaterReading { get; set; }
        int NumberOfTenants { get; set; }
        int RecordId { get; set; }
        decimal TotalCost { get; set; }
    }
}