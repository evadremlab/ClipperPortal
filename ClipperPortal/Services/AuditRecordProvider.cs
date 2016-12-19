using System;
using System.Collections.Generic;
using System.Linq;

using ClipperPortal.Models;

namespace ClipperPortal.Services
{
    public static class AuditRecordProvider
    {
        public static IEnumerable<AuditRecord> Get()
        {
            using (var context = new ClipperContext())
            {
                return context.AuditRecords.ToList();
            }
        }

        public static void Create(AuditRecord data)
        {
            using (var context = new ClipperContext())
            {
                context.AuditRecords.Add(data);
                context.SaveChanges();
            }
        }
    }
}