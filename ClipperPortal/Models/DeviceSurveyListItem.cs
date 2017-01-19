using System;
using System.ComponentModel.DataAnnotations;

using MySql.Data.MySqlClient;

using ClipperPortal.Extensions;

namespace ClipperPortal.Models
{
    public class DeviceSurveyListItem
    {
        public int ID { get; set; }

        public string Operator { get; set; }

        [Display(Name = "Reporting Period")]
        public string ReportingPeriod { get; set;}

        [Display(Name = "Record Status")]
        public string RecordStatus { get; set; }

        [Display(Name = "Expansion Vehicles")]
        public string ExpansionVehicles { get; set; }

        [Display(Name = "Replacement Vehicles")]
        public string ReplacementVehicles { get; set; }

        [Display(Name = "Last Updated")]
       public DateTime LastUpdated { get; set; }

        public void Populate(MySqlDataReader reader)
        {
            var expansionVehicles = reader.GetValueOfType<int>("ExpansionVehicles");
            var replacementVehicles = reader.GetValueOfType<int>("ReplacementVehicles");

            this.ID = reader.GetValueOfType<int>("ID");
            this.ReportingPeriod = reader.GetValueOfType<string>("ReportingPeriod");
            this.Operator = reader.GetValueOfType<string>("Operator");
            this.RecordStatus = reader.GetValueOfType<string>("RecordStatus");
            this.ExpansionVehicles = expansionVehicles == 0 ? string.Empty : expansionVehicles.ToString();
            this.ReplacementVehicles = replacementVehicles == 0 ? string.Empty : replacementVehicles.ToString();
            this.LastUpdated = reader.GetValueOfType<DateTime>("LastUpdated");
        }
    }
}