using System;
using System.ComponentModel.DataAnnotations;

using MySql.Data.MySqlClient;

using ClipperPortal.Extensions;

namespace ClipperPortal.Models
{
    public class ReportMatrix
    {
        [Display(Name = "Calendar Year")]
        public string CalendarYear { get; set;}

        public string Agency { get; set; }

        [Display(Name = "Expansion Vehicles")]
        public int ExpansionVehicleCount { get; set; }

        [Display(Name = "Replacement Vehicles")]
        public int ReplacementVehicleCount { get; set; }

        [Display(Name = "Record Status")]
        public string RecordStatus { get; set; }

        public void Populate(MySqlDataReader reader)
        {
            this.CalendarYear = reader.GetValueOfType<string>("CalendarYear");
            this.Agency = reader.GetValueOfType<string>("Agency");
            this.ExpansionVehicleCount = reader.GetValueOfType<int>("ExpansionVehicleCount");
            this.ReplacementVehicleCount = reader.GetValueOfType<int>("ReplacementVehicleCount");
            this.RecordStatus = reader.GetValueOfType<string>("RecordStatus");
        }
    }
}