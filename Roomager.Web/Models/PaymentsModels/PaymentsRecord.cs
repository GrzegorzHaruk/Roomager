using System;
using System.ComponentModel.DataAnnotations;

namespace Roomager.Web.Models.PaymentsModels
{
    public class PaymentsRecord
    {
        public int RecordId { get; set; }
        
        [Required]
        public double EnergyReading { get; set; }

        [Required]
        public double EnergyUsage { get; set; }

        [Required]
        public decimal EnergyCost { get; set; }

        [Required]
        public double ColdWaterReading { get; set; }

        [Required]
        public decimal ColdWaterCost { get; set; }

        [Required]
        public double HotWaterReading { get; set; }

        [Required]
        public decimal HotWaterCost { get; set; }

        [Required]
        public decimal GasCost { get; set; }

        [Required]
        public int NumberOfTenants { get; set; }

        [Required]
        public decimal TotalCost { get; set; }

        [Required]
        public decimal CostPerPerson { get; set; }

        [Required]
        public DateTime AddDate { get; set; } = DateTime.Now;

        public string Comment { get; set; }
    }
}
