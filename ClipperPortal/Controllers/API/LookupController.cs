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
        [Route("api/Lookup/Agencies")]
        public IEnumerable<Agency> Agencies()
        {
            var data = new List<Agency> { new Agency { Name = "-- select --" } };

            foreach (var item in StaticDataProvider.GetAgencies())
            {
                data.Add(item);
            }

            return data;
        }

        [HttpGet]
        [Route("api/Lookup/CalendarYears")]
        public IEnumerable<CalendarYear> CalendarYears()
        {
            var data = new List<CalendarYear> { new CalendarYear { Name = "-- select --" } };

            foreach (var item in StaticDataProvider.GetCalendarYears())
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
