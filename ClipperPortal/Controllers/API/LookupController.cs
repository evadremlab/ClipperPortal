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
            return StaticDataProvider.GetAgencies();
        }

        [HttpGet]
        [Route("api/Lookup/CalendarYears")]
        public IEnumerable<CalendarYear> CalendarYears()
        {
            return StaticDataProvider.GetCalendarYears();
        }
    }
}
