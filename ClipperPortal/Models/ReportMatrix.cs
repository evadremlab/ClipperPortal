using System;
using System.ComponentModel.DataAnnotations;

using MySql.Data.MySqlClient;

using ClipperPortal.Extensions;

namespace ClipperPortal.Models
{
    public class ReportMatrix
    {
        [Display(Name = "Operator")]
        public string Agency { get; set; }

        [Display(Name = "Calendar Year")]
        public string CalendarYear { get; set;}

        [Display(Name = "Record Status")]
        public string RecordStatus { get; set; }

        [Display(Name = "New Vehicles")]
        public string NewVehicles { get; set; }

        [Display(Name = "Expansion Vehicles")]
        public string ExpansionVehicles { get; set; }

        [Display(Name = "Replacement Vehicles")]
        public string ReplacementVehicles { get; set; }

        public void Populate(MySqlDataReader reader)
        {
            this.CalendarYear = reader.GetValueOfType<string>("CalendarYear");
            this.Agency = reader.GetValueOfType<string>("Agency");
            this.RecordStatus = reader.GetValueOfType<string>("RecordStatus");
            this.NewVehicles = reader.GetValueOfType<string>("NewVehicles");
            this.ExpansionVehicles = reader.GetValueOfType<string>("ExpansionVehicles");
            this.ReplacementVehicles = reader.GetValueOfType<string>("ReplacementVehicles");
        }
    }
}