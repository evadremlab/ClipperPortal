using System;
using System.Collections.Generic;
using System.Linq;

using ClipperPortal.Models;

namespace ClipperPortal.Services
{
    public static class StaticDataProvider
    {
        public static IEnumerable<Operator> GetOperators()
        {
            using (var context = new ClipperContext())
            {
                return context.Operators.ToList();
            }
        }

        public static IEnumerable<ReportingPeriod> GetReportingPeriods()
        {
            using (var context = new ClipperContext())
            {
                return context.ReportingPeriods.ToList();
            }
        }
    }
}