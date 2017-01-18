using System;
using System.Collections.Generic;
using System.Web.Http;

using ClipperPortal.Models;
using ClipperPortal.Services;

namespace ClipperPortal.Controllers
{
    public class LookupController : ApiController
    {
        [HttpGet]
        [Route("api/Lookup/Operators")]
        public IEnumerable<Operator> Operators()
        {
            var data = new List<Operator> { new Operator { Name = "-- select --" } };

            foreach (var item in StaticDataProvider.GetOperators())
            {
                data.Add(item);
            }

            return data;
        }

        [HttpGet]
        [Route("api/Lookup/ReportingPeriods")]
        public IEnumerable<ReportingPeriod> ReportingPeriods()
        {
            var data = new List<ReportingPeriod> { new ReportingPeriod { Name = "-- select --" } };

            foreach (var item in StaticDataProvider.GetReportingPeriods())
            {
                data.Add(item);
            }

            return data;
        }

        [HttpGet]
        [Route("api/Lookup/RecordStatuses")]
        public IEnumerable<RecordStatus> RecordStatuses()
        {
            return new List<RecordStatus> {
                new RecordStatus { Name = "-- select --" },
                new RecordStatus { Name = "Planned" },
                new RecordStatus { Name = "Completed" }
            };
        }
    }
}
