using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

// http://lvasquez.github.io/2014/11/18/EntityFramework-MySql/
// https://msdn.microsoft.com/en-us/library/jj592676(v=vs.113).aspx

namespace ClipperPortal.Models
{
    public partial class ClipperContext : DbContext
    {
        public ClipperContext() : base(nameOrConnectionString: "DefaultConnection") { }

        public DbSet<Agency> Agencies { get; set; }
        public DbSet<AuditRecord> AuditRecords { get; set; }
        public DbSet<Calendar> CalendarYears { get; set; }
        public DbSet<ExpansionDetail> ExpansionDetails { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<ReplacementVehicle> ReplacementVehicles { get; set; }

        private object GetPrimaryKeyValue(DbEntityEntry entry)
        {
            var objectStateEntry = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity);
            return objectStateEntry.EntityKey.EntityKeyValues[0].Value;
        }

        private string getStringValue(Object obj)
        {
            return obj == null ? "" : obj.ToString();
        }

        // https://www.exceptionnotfound.net/entity-change-tracking-using-dbcontext-in-entity-framework-6/

        public override int SaveChanges()
        {
            var now = DateTime.UtcNow;
            var modifiedEntities = ChangeTracker.Entries().Where(p => p.State == EntityState.Modified).ToList();

            foreach (var entity in modifiedEntities)
            {
                var primaryKey = GetPrimaryKeyValue(entity);
                var entityName = entity.Entity.GetType().Name;
                var databaseValues = entity.GetDatabaseValues();

                foreach (var propName in entity.OriginalValues.PropertyNames)
                {
                    var currentValue = getStringValue(entity.CurrentValues[propName]);
                    var originalValue = getStringValue(databaseValues.GetValue<object>(propName));

                    if (originalValue != currentValue)
                    {
                        var auditRecord = new AuditRecord()
                        {
                            EntityName = entityName,
                            PrimaryKeyValue = primaryKey.ToString(),
                            PropertyName = propName,
                            OldValue = originalValue,
                            NewValue = currentValue,
                            DateChanged = now,
                            UserName = string.Empty
                        };

                        AuditRecords.Add(auditRecord);
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}