using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using ClipperPortal.Models;

namespace ClipperPortal.Services
{
    public static class ExpansionDetailProvider
    {
        public static IEnumerable<ExpansionDetail> Get()
        {
            using (var context = new ClipperContext())
            {
                return context.ExpansionDetails.ToList();
            }
        }

        public static ExpansionDetail Get(int id)
        {
            using (var context = new ClipperContext())
            {
                return context.ExpansionDetails.Where(x => x.ID == id).FirstOrDefault();
            }
        }

        public static void Create(ExpansionDetail data)
        {
            using (var context = new ClipperContext())
            {
                context.ExpansionDetails.Add(data);
                context.SaveChanges();
            }
        }

        public static void Update(int id, ExpansionDetail data)
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
                var record = context.ExpansionDetails.Where(x => x.ID == id).FirstOrDefault();

                if (record != null)
                {
                    context.ExpansionDetails.Attach(record);
                    context.ExpansionDetails.Remove(record);
                }
            }
        }
    }
}