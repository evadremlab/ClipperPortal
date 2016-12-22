using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using ClipperPortal.Models;

namespace ClipperPortal.Services
{
    public static class ReplacementVehicleProvider
    {
        public static IEnumerable<ReplacementVehicle> GetAll()
        {
            using (var context = new ClipperContext())
            {
                return context.ReplacementVehicles.ToList();
            }
        }

        public static ReplacementVehicle Get(int id)
        {
            using (var context = new ClipperContext())
            {
                return context.ReplacementVehicles.Where(x => x.ID == id).FirstOrDefault();
            }
        }

        public static void Create(ReplacementVehicle data)
        {
            using (var context = new ClipperContext())
            {
                context.ReplacementVehicles.Add(data);
                context.SaveChanges();
            }
        }

        public static void Update(int id, ReplacementVehicle data)
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
                var record = context.ReplacementVehicles.Where(x => x.ID == id).FirstOrDefault();

                if (record != null)
                {
                    context.ReplacementVehicles.Attach(record);
                    context.ReplacementVehicles.Remove(record);
                    context.SaveChanges();
                }
            }
        }
    }
}