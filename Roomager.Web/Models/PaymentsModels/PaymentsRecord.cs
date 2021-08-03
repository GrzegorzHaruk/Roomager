using System;
using System.ComponentModel.DataAnnotations;

namespace Roomager.Web.Models.PaymentsModels
{
    public class PaymentsRecord
    {
        public PaymentsRecord()
        {
            AddDate = DateTime.Now;
        }

        public int RecordId { get; set; }
        
        [Required]
        [Display(Name = "Energy Reading")]
        public double EnergyReading { get; set; }

        [Required]
        [Display(Name = "Energy Usage")]
        public double EnergyUsage { get; set; }

        [Required]
        [Display(Name = "Energy Cost")]
        public decimal EnergyCost { get; set; }

        [Required]
        [Display(Name = "Cold Water Reading")]
        public double ColdWaterReading { get; set; }

        [Required]
        [Display(Name = "Cold Water Cost")]
        public decimal ColdWaterCost { get; set; }

        [Required]
        [Display(Name = "Hot Water Reading")]
        public double HotWaterReading { get; set; }

        [Required]
        [Display(Name = "Hot Water Cost")]
        public decimal HotWaterCost { get; set; }

        [Required]
        [Display(Name = "Gas Cost")]
        public decimal GasCost { get; set; }

        [Required]
        [Display(Name = "Number Of Tenants")]
        public int NumberOfTenants { get; set; }

        [Required]
        [Display(Name = "Total Cost")]
        public decimal TotalCost { get; set; }

        [Required]
        [Display(Name = "Cost Per Person")]
        public decimal CostPerPerson { get; set; }

        [Required]
        [Display(Name = "Add Date")]
        public DateTime AddDate { get; set; }

        [Display(Name = "Comment")]
        public string Comment { get; set; }
    }
}
