using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using ClipperPortal.Models;

namespace ClipperPortal.Services
{
    public static class DeviceSurveyProvider
    {
        public static IEnumerable<DeviceSurvey> GetAll()
        {
            using (var context = new ClipperContext())
            {
                return context.DeviceSurveys.ToList();
            }
        }

        public static DeviceSurvey Get(int id)
        {
            using (var context = new ClipperContext())
            {
                return context.DeviceSurveys.Where(x => x.ID == id).FirstOrDefault();
            }
        }

        public static void Create(DeviceSurvey data)
        {
            using (var context = new ClipperContext())
            {
                context.DeviceSurveys.Add(data);
                context.SaveChanges();
            }
        }

        public static void Update(int id, DeviceSurvey data)
        {
            using (var context = new ClipperContext())
            {
                context.Entry(data).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new ClipperContext())
            {
                var record = context.DeviceSurveys.Where(x => x.ID == id).FirstOrDefault();

                if (record != null)
                {
                    context.DeviceSurveys.Attach(record);
                    context.DeviceSurveys.Remove(record);
                    context.SaveChanges();
                }
            }
        }
    }
}