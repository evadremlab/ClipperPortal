using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClipperPortal.Models
{
    [Table("calendaryears")]
    public class Calendar
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}