using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;

using MySql.Data.MySqlClient;

using ClipperPortal.Models;

namespace ClipperPortal.Services
{
    public static class DeviceSurveyProvider
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static IEnumerable<DeviceSurvey> GetAll()
        {
            using (var context = new ClipperContext())
            {
                return context.DeviceSurveys.OrderBy(x => x.ReportingPeriod).ThenBy(x => x.Operator).ThenBy(x => x.RecordStatus).ToList();
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
                context.Operator = deviceSurvey.Operator;
                context.UserName = deviceSurvey.UserName;
                context.SaveChanges(); // so we get the primary key of the created record

                // IF CREATING ONE AUDITRECORD FOR A NEW RECORD
                var auditRecord = new AuditRecord()
                {
                    EntityName = "DeviceSurvey",
                    PrimaryKeyValue = deviceSurvey.ID.ToString(),
                    Action = "Created",
                    PropertyName = string.Empty,
                    OldValue = null,
                    NewValue = null,
                    DateChanged = now,
                    UserName = deviceSurvey.UserName,
                    Operator = deviceSurvey.Operator
                };

                context.AuditRecords.Add(auditRecord);

                // IF CREATING AUDITRECORD FOR EACH FIELD OF A NEW RECORD
                //foreach (var prop in deviceSurvey.GetType().GetProperties())
                //{
                //    if (prop.Name == "DateCreated" || prop.Name == "LastUpdated")
                //    {
                //        continue;
                //    }

                //    var currentValue = prop.GetValue(deviceSurvey, null);
                //    var currentStringValue = currentValue == null ? "" : currentValue.ToString();

                //    var auditRecord = new AuditRecord()
                //    {
                //        EntityName = "DeviceSurvey",
                //        PrimaryKeyValue = deviceSurvey.ID.ToString(),
                //        Action = "Created",
                //        PropertyName = prop.Name,
                //        OldValue = null,
                //        NewValue = currentStringValue,
                //        DateChanged = now,
                //        UserName = deviceSurvey.UserName,
                //        Operator = deviceSurvey.Operator
                //    };

                //    context.AuditRecords.Add(auditRecord);
                //}

                context.SaveChanges();
            }
        }

        public static void Update(DeviceSurvey deviceSurvey)
        {
            using (var context = new ClipperContext())
            {
                context.Entry(deviceSurvey).State = EntityState.Modified;
                context.Operator = deviceSurvey.Operator;
                context.UserName = deviceSurvey.UserName;
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
                    context.Operator = deviceSurvey.Operator;
                    context.UserName = deviceSurvey.UserName;
                    context.SaveChanges();
                }
            }
        }

        public static IEnumerable<DeviceSurveyListItem> GetList()
        {
            var list = new List<DeviceSurveyListItem>();

            using (var connection = new MySqlConnection(connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "getdevicesurveylist";
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var data = new DeviceSurveyListItem();

                            data.Populate(reader);

                            list.Add(data);
                        }
                    }

                }
            };

            return list;
        }
    }
}