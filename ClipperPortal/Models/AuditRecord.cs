using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClipperPortal.Models
{
    [Table("auditrecords")]
    public class AuditRecord
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Entity")]
        public string EntityName { get; set; }

        [Display(Name = "ID")]
        public string PrimaryKeyValue { get; set; }

        [Display(Name = "Action")]
        public string Action { get; set; }

        [Display(Name = "Property")]
        public string PropertyName { get; set; }

        [Display(Name = "Old Value")]
        public string OldValue { get; set; }

        [Display(Name = "New Value")]
        public string NewValue { get; set; }

        [Display(Name = "Date Changed")]
        public DateTime DateChanged { get; set; }

        [Display(Name = "Changed By")]
        public string UserName { get; set; }
    }
}