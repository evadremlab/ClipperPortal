using System;
using System.ComponentModel.DataAnnotations;

using Foolproof;

namespace ClipperPortal.Models
{
    public class AbstractRecord
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "field is required")]
        [Display(Name = "Operator")]
        public string Agency { get; set; }

        [Required(ErrorMessage = "field is required")]
        [Display(Name = "Calendar Year")]
        public string CalendarYear { get; set; }

        [Required(ErrorMessage = "field is required")]
        public string Manufacturer { get; set; }

        [Display(Name = "Other Manufacturer")]
        [RequiredIf("Manufacturer", "other", ErrorMessage = "field is required.")]
        public string OtherManufacturer { get; set; }

        public string UserName { get; set; }

        [Display(Name = "Record Status")]
        public string RecordStatus { get; set; }
    }
}