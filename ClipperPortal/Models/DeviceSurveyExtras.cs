using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClipperPortal.Models
{
    /// <summary>
    /// Holds properties that are not mapped to the database.
    /// </summary>
    public partial class DeviceSurvey
    {
        [NotMapped]
        public bool IsGilligNewVehiclesAndModelRequired
        {
            get { return this.IsExpectingNewVehicles && this.HasGillig; }
        }

        [NotMapped]
        public bool IsNewFlyerNewVehiclesAndModelRequired
        {
            get { return this.IsExpectingNewVehicles && this.HasNewFlyer; }
        }

        [NotMapped]
        public bool IsElDoradoNewVehiclesAndModelRequired
        {
            get { return this.IsExpectingNewVehicles && this.HasElDorado; }
        }

        [NotMapped]
        public bool IsOtherNewVehiclesAndModelRequired
        {
            get { return this.IsExpectingNewVehicles && this.HasOther; }
        }

        [NotMapped]
        public string HasGilligYN
        {
            get { return this.HasGillig ? "Y" : "N"; }
        }

        [NotMapped]
        public string HasNewFlyerYN
        {
            get { return this.HasNewFlyer ? "Y" : "N"; }
        }

        [NotMapped]
        public string HasElDoradoYN
        {
            get { return this.HasElDorado ? "Y" : "N"; }
        }
    }
}