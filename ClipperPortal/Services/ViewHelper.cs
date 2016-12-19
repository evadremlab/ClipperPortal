using System;
using System.Collections.Generic;
using System.Web.Mvc;

using ClipperPortal.Models;

namespace ClipperPortal.Services
{
    public class LookupData
    {
        public SelectList Agencies { get; set; }
        public SelectList CalendarYears { get; set; }
        public SelectList Manufacturers { get; set; }
        public SelectList RecordStatus { get; set; }
    }

    public static class ViewHelper
    {
        public static LookupData GetLookupData()
        {
            var agencies = StaticDataProvider.GetAgencies();
            var calendarYears = StaticDataProvider.GetCalendarYears();
            var manufacturers = StaticDataProvider.GetManufacturers();

            var recordStatus = new Dictionary<string, string>();
            recordStatus.Add("Planned", "Planned");
            recordStatus.Add("Completed", "Completed");

            return new LookupData
            {
                Agencies = new SelectList(agencies, "Name", "Name"),
                CalendarYears = new SelectList(calendarYears, "Name", "Name"),
                Manufacturers = new SelectList(manufacturers, "Name", "Name"),
                RecordStatus = new SelectList(recordStatus, "Key", "Value")
            };
        }
    }
}