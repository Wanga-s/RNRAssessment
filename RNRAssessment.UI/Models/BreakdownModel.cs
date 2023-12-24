using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RNRAssessment.UI.Models
{
    public class BreakdownModel
    {
        public BreakdownModel() {
            Id            = 0;
            BreakdownDate = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [Remote("CheckForBreakdownReference", "Breakdown",ErrorMessage ="Breakdown Reference already exists",AdditionalFields = "Id")]
        [DisplayName("Breakdown Reference")]
        public string? BreakdownReference { get; set; }
        [DisplayName("Company Name")]
        public string? CompanyName { get; set; }
        [DisplayName("Driver Name")]
        public string? DriverName { get; set; }
        [Required]
        [DisplayName("Registration Number")]
        public string? RegistrationNumber { get; set; }
        [DisplayName("Breakdown Date")]
        public DateTime BreakdownDate { get; set; }
    }
}
