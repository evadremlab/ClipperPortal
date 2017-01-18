using System;
using System.Collections.Generic;
using System.Web.Mvc;

using ClipperPortal.Models;

namespace ClipperPortal.Services
{
    public class LookupData
    {
        public SelectList Operators { get; set; }
        public SelectList ReportingPeriods { get; set; }
        public SelectList RecordStatus { get; set; }
    }

    public static class ViewHelper
    {
        public static LookupData GetLookupData()
        {
            var operators = StaticDataProvider.GetOperators();
            var reportingPeriods = StaticDataProvider.GetReportingPeriods();

            var recordStatus = new Dictionary<string, string>();
            recordStatus.Add("Planned", "Planned");
            recordStatus.Add("Completed", "Completed");

            return new LookupData
            {
                Operators = new SelectList(operators, "Name", "Name"),
                ReportingPeriods = new SelectList(reportingPeriods, "Name", "Name"),
                RecordStatus = new SelectList(recordStatus, "Key", "Value")
            };
        }
    }
}