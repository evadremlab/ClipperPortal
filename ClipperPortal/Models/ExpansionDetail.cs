using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClipperPortal.Models
{
    [Table("expansiondetails")]
    public class ExpansionDetail : AbstractRecord
    {
        [Display(Name = "Do you own existing vehicles of the same/similar model?")]
        public bool HaveExistingVehicles { get; set; }

        [Display(Name = "Will you be seeking to install Clipper® equipment in the same/similar location on the new vehicles?")]
        public bool HaveExistingVehicleDetails { get; set; }

        [Display(Name = "Specify the model and equipment placement details")]
        public string ReplacementVehicleDetails { get; set; }

        [Range(0, 99)]
        [Required(ErrorMessage = "field is required")]
        [Display(Name = "How many of these are vehicle replacements?")]
        public int VehicleCount { get; set; }

        [Range(0, 99)]
        [Required(ErrorMessage = "field is required")]
        [Display(Name = "How many of these are fleet additions?")]
        public int AdditionalVehicleCount { get; set; }

        [Required(ErrorMessage = "field is required")]
        [Display(Name = "When do vehicles start the manufacturing line?")]
        public DateTime ManufacturingDate { get; set; }

        [Required(ErrorMessage = "field is required")]
        [Display(Name = "When are vehicles anticipated to be delivered to your facility?")]
        public DateTime DeliveryDate { get; set; }

        [Display(Name = "Does it specify Clipper® pre-wire requirements as part of the scope of work?")]
        public string PreWireRequirements { get; set; }

        [Display(Name = "Has your vehicle manufacturer included costs associated with pre-wiring your vehicle in the agreed upon quote/procurement?")]
        public string IncludedCosts { get; set; }
    }
}
