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
        public DbSet<DeviceSurvey> DeviceSurveys { get; set; }

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

            _TrackUpdated(now);
            _TrackDeleted(now);
            // Create tracking is done in DeviceSurveyProvider

            return base.SaveChanges();
        }

        private void _TrackUpdated(DateTime now)
        {
            var entities = ChangeTracker.Entries().Where(p => p.State == EntityState.Modified).ToList();

            foreach (var entity in entities)
            {
                var primaryKey = GetPrimaryKeyValue(entity);
                var entityName = entity.Entity.GetType().Name;
                var databaseValues = entity.GetDatabaseValues();

                foreach (var propName in entity.OriginalValues.PropertyNames)
                {
                    if (propName == "DateCreated" || propName == "LastUpdated")
                    {
                        continue;
                    }

                    var currentValue = getStringValue(entity.CurrentValues[propName]);
                    var originalValue = getStringValue(databaseValues.GetValue<object>(propName));

                    if (originalValue != currentValue)
                    {
                        var auditRecord = new AuditRecord()
                        {
                            EntityName = entityName,
                            PrimaryKeyValue = primaryKey.ToString(),
                            RecordType = "Updated",
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
        }

        private void _TrackDeleted(DateTime now)
        {
            var entities = ChangeTracker.Entries().Where(p => p.State == EntityState.Deleted).ToList();

            foreach (var entity in entities)
            {
                var primaryKey = GetPrimaryKeyValue(entity);
                var entityName = entity.Entity.GetType().Name;

                var auditRecord = new AuditRecord()
                {
                    EntityName = entityName,
                    PrimaryKeyValue = primaryKey.ToString(),
                    RecordType = "Deleted",
                    DateChanged = now,
                    UserName = string.Empty
                };

                AuditRecords.Add(auditRecord);
            }
        }
    }
}