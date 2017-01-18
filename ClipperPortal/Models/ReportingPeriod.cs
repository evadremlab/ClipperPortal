using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClipperPortal.Models
{
    [Table("reportingperiods")]
    public class ReportingPeriod
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}