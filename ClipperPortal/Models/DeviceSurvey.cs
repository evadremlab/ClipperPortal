using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Foolproof;

namespace ClipperPortal.Models
{
    /// <summary>
    /// Holds properties that are mapped to the database.
    /// </summary>
    [Table("devicesurvey")]
    public partial class DeviceSurvey
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Calendar Year")]
        [Required(ErrorMessage = "field is required")]
        public string CalendarYear { get; set; }

        [Display(Name = "Operator")]
        [Required(ErrorMessage = "field is required")]
        public string Agency { get; set; }

        [Display(Name = "Operator Staff Name")]
        [Required(ErrorMessage = "field is required")]
        public string UserName { get; set; }

        [Display(Name = "Operator Staff Email")]
        [Required(ErrorMessage = "field is required")]
        public string Email { get; set; }

        [Display(Name = "Are you anticipating delivery of new vehicles in this calendar year?")]
        public bool IsExpectingNewVehicles { get; set; }

        [Display(Name = "Gillig")]
        public bool HasGillig { get; set; }

        [Display(Name = "New Flyer")]
        public bool HasNewFlyer { get; set; }

        [Display(Name = "El Dorado")]
        public bool HasElDorado { get; set; }

        [Display(Name = "Other")]
        public bool HasOther { get; set; }

        [Display(Name = "Other Name")]
        [RequiredIf("HasOther", true, ErrorMessage = "field is required")]
        public string OtherName { get; set; }

        #region Gillig
        [Display(Name = "Gillig")]
        [RequiredIf("IsGilligNewVehiclesAndModelRequired", true, ErrorMessage = "field is required")]
        public string GilligNewVehicles { get; set; }

        [Display(Name = "Gillig")]
        [RequiredIf("IsGilligNewVehiclesAndModelRequired", true, ErrorMessage = "field is required")]
        public string GilligNewModel { get; set; }

        [Display(Name = "Gillig Vehicle Replacement")]
        [RequiredIf("HasGillig", true, ErrorMessage = "field is required")]
        public string GilligReplacementVehicles { get; set; }

        [Display(Name = "Gillig Vehicle Replacement")]
        [RequiredIf("HasGillig", true, ErrorMessage = "field is required")]
        public string GilligReplacementManufacturingDate { get; set; }

        [Display(Name = "Gillig Vehicle Replacement")]
        [RequiredIf("HasGillig", true, ErrorMessage = "field is required")]
        public string GilligReplacementDeliveryDate { get; set; }

        [Display(Name = "Gillig Fleet Expansion")]
        [RequiredIf("HasGillig", true, ErrorMessage = "field is required")]
        public string GilligExpansionVehicles { get; set; }

        [Display(Name = "Gillig Fleet Expansion")]
        [RequiredIf("HasGillig", true, ErrorMessage = "field is required")]
        public string GilligExpansionManufacturingDate { get; set; }

        [Display(Name = "Gillig Fleet Expansion")]
        [RequiredIf("HasGillig", true, ErrorMessage = "field is required")]
        public string GilligExpansionDeliveryDate { get; set; }
        #endregion

        #region NewFlyer
        [Display(Name = "New Flyer")]
        [RequiredIf("IsNewFlyerNewVehiclesAndModelRequired", true, ErrorMessage = "field is required")]
        public string FlyerNewVehicles { get; set; }

        [Display(Name = "New Flyer")]
        [RequiredIf("IsNewFlyerNewVehiclesAndModelRequired", true, ErrorMessage = "field is required")]
        public string NewFlyerNewModel { get; set; }

        [Display(Name = "New Flyer Vehicle Replacement")]
        [RequiredIf("HasNewFlyer", true, ErrorMessage = "field is required")]
        public string NewFlyerReplacementVehicles { get; set; }

        [Display(Name = "New Flyer Vehicle Replacement")]
        [RequiredIf("HasNewFlyer", true, ErrorMessage = "field is required")]
        public string NewFlyerReplacementManufacturingDate { get; set; }

        [Display(Name = "New Flyer Vehicle Replacement")]
        [RequiredIf("HasNewFlyer", true, ErrorMessage = "field is required")]
        public string NewFlyerReplacementDeliveryDate { get; set; }

        [Display(Name = "New Flyer Fleet Expansion")]
        [RequiredIf("HasNewFlyer", true, ErrorMessage = "field is required")]
        public string NewFlyerExpansionVehicles { get; set; }

        [Display(Name = "New Flyer Fleet Expansion")]
        [RequiredIf("HasNewFlyer", true, ErrorMessage = "field is required")]
        public string NewFlyerExpansionManufacturingDate { get; set; }

        [Display(Name = "New Flyer Fleet Expansion")]
        [RequiredIf("HasNewFlyer", true, ErrorMessage = "field is required")]
        public string NewFlyerExpansionDeliveryDate { get; set; }
        #endregion

        #region ElDorado
        [Display(Name = "El Dorado")]
        [RequiredIf("IsElDoradoNewVehiclesAndModelRequired", true, ErrorMessage = "field is required")]
        public string ElDoradoNewVehicles { get; set; }

        [Display(Name = "El Dorado")]
        [RequiredIf("IsElDoradoNewVehiclesAndModelRequired", true, ErrorMessage = "field is required")]
        public string ElDoradoNewModel { get; set; }

        [Display(Name = "El Dorado Vehicle Replacement")]
        [RequiredIf("HasElDorado", true, ErrorMessage = "field is required")]
        public string ElDoradoReplacementVehicles { get; set; }

        [Display(Name = "El Dorado Vehicle Replacement")]
        [RequiredIf("HasElDorado", true, ErrorMessage = "field is required")]
        public string ElDoradoReplacementManufacturingDate { get; set; }

        [Display(Name = "El Dorado Vehicle Replacement")]
        [RequiredIf("HasElDorado", true, ErrorMessage = "field is required")]
        public string ElDoradoReplacementDeliveryDate { get; set; }

        [Display(Name = "El Dorado Fleet Expansion")]
        [RequiredIf("HasElDorado", true, ErrorMessage = "field is required")]
        public string ElDoradoExpansionVehicles { get; set; }

        [Display(Name = "El Dorado Fleet Expansion")]
        [RequiredIf("HasElDorado", true, ErrorMessage = "field is required")]
        public string ElDoradoExpansionManufacturingDate { get; set; }

        [Display(Name = "El Dorado Fleet Expansion")]
        [RequiredIf("HasElDorado", true, ErrorMessage = "field is required")]
        public string ElDoradoExpansionDeliveryDate { get; set; }
        #endregion

        #region Other
        [Display(Name = "Other")]
        [RequiredIf("IsOtherNewVehiclesAndModelRequired", true, ErrorMessage = "field is required")]
        public string OtherNewVehicles { get; set; }

        [Display(Name = "Other")]
        [RequiredIf("IsOtherNewVehiclesAndModelRequired", true, ErrorMessage = "field is required")]
        public string OtherNewModel { get; set; }

        [Display(Name = "Other - Vehicle Replacement")]
        [RequiredIf("HasOther", true, ErrorMessage = "field is required")]
        public string OtherReplacementVehicles { get; set; }

        [Display(Name = "Other - Vehicle Replacement")]
        [RequiredIf("HasOther", true, ErrorMessage = "field is required")]
        public string OtherReplacementManufacturingDate { get; set; }

        [Display(Name = "Other - Vehicle Replacement")]
        [RequiredIf("HasOther", true, ErrorMessage = "field is required")]
        public string OtherReplacementDeliveryDate { get; set; }

        [Display(Name = "Other - Fleet Expansion")]
        [RequiredIf("HasOther", true, ErrorMessage = "field is required")]
        public string OtherExpansionVehicles { get; set; }

        [Display(Name = "Other - Fleet Expansion")]
        [RequiredIf("HasOther", true, ErrorMessage = "field is required")]
        public string OtherExpansionManufacturingDate { get; set; }

        [Display(Name = "Other - Fleet Expansion")]
        [RequiredIf("HasOther", true, ErrorMessage = "field is required")]
        public string OtherExpansionDeliveryDate { get; set; }
        #endregion

        [Display(Name = "Do you own existing vehicles of the same/similar model?")]
        public bool OwnExistingVehicles { get; set; }

        [Display(Name = "Assuming the internal layout of the vehicle is similar to previous versions, will you be seeking to install Clipper® equipment in the same/similar location on the new vehicles?")]
        [RequiredIf("OwnExistingVehicles", true, ErrorMessage = "field is required")]
        public string ExistingVehicleDetails { get; set; }

        [Display(Name = "Specify the model and equipment placement details")]
        [RequiredIf("OwnExistingVehicles", false, ErrorMessage = "field is required")]
        public string ReplacementVehicleDetails { get; set; }

        [Display(Name = "Does it specify Clipper® pre-wire requirements as part of the scope of work?")]
        public string PreWireRequirements { get; set; }

        [Display(Name = "Has your vehicle manufacturer included costs associated with pre-wiring your vehicle in the agreed upon quote/procurement?")]
        public string IncludedCosts { get; set; }

        [Display(Name = "Record Status")]
        [Required(ErrorMessage = "field is required")]
        public string RecordStatus { get; set; }
    }
}