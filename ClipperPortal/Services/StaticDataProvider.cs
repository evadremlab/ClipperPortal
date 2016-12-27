using System;
using System.Collections.Generic;
using System.Linq;

using ClipperPortal.Models;

namespace ClipperPortal.Services
{
    public static class StaticDataProvider
    {
        public static IEnumerable<Agency> GetAgencies()
        {
            using (var context = new ClipperContext())
            {
                return context.Agencies.ToList();
            }
        }

        public static IEnumerable<CalendarYear> GetCalendarYears()
        {
            using (var context = new ClipperContext())
            {
                return context.CalendarYears.ToList();
            }
        }
    }
}