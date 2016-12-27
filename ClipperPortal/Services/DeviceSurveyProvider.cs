using System;
using System.Collections.Generic;
using System.Linq;

using ClipperPortal.Models;
using System.Data.Entity;

namespace ClipperPortal.Services
{
    public static class DeviceSurveyProvider
    {
        public static IEnumerable<DeviceSurvey> GetAll()
        {
            using (var context = new ClipperContext())
            {
                return context.DeviceSurveys.OrderBy(x => x.CalendarYear).ThenBy(x => x.Agency).ThenBy(x => x.RecordStatus).ToList();
            }
        }

        public static DeviceSurvey Get(int id)
        {
            using (var context = new ClipperContext())
            {
                return context.DeviceSurveys.Find(id);
            }
        }

        public static void Create(DeviceSurvey deviceSurvey)
        {
            var now = DateTime.UtcNow;

            using (var context = new ClipperContext())
            {
                context.DeviceSurveys.Add(deviceSurvey);
                context.SaveChanges(); // so we get the primary key of the created record

                foreach (var prop in deviceSurvey.GetType().GetProperties())
                {
                    if (prop.Name == "DateCreated" || prop.Name == "LastUpdated")
                    {
                        continue;
                    }

                    var currentValue = prop.GetValue(deviceSurvey, null);
                    var currentStringValue = currentValue == null ? "" : currentValue.ToString();

                    var auditRecord = new AuditRecord()
                    {
                        EntityName = "DeviceSurvey",
                        PrimaryKeyValue = deviceSurvey.ID.ToString(),
                        Action = "Created",
                        PropertyName = prop.Name,
                        OldValue = null,
                        NewValue = currentStringValue,
                        DateChanged = now,
                        UserName = string.Empty
                    };

                    context.AuditRecords.Add(auditRecord);
                }

                context.SaveChanges();
            }
        }

        public static void Update(DeviceSurvey deviceSurvey)
        {
            using (var context = new ClipperContext())
            {
                context.Entry(deviceSurvey).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new ClipperContext())
            {
                var deviceSurvey = context.DeviceSurveys.Find(id);

                if (deviceSurvey != null)
                {
                    context.DeviceSurveys.Remove(deviceSurvey);
                    context.SaveChanges();
                }
            }
        }
    }
}