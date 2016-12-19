using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClipperPortal.Models
{
    [Table("replacementvehicles")]
    public class ReplacementVehicle : AbstractRecord
    {
        [Required(ErrorMessage = "field is required")]
        [Display(Name = "Vehicle Count")]
        public int VehicleCount { get; set; }

        [Required(ErrorMessage = "field is required")]
        [Display(Name = "Vehicle Model")]
        public string VehicleModel { get; set; }
    }
}
