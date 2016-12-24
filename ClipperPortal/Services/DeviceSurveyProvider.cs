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
                return context.DeviceSurveys.ToList();
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
            using (var context = new ClipperContext())
            {
                context.DeviceSurveys.Add(deviceSurvey);
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