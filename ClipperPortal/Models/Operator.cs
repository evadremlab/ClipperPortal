using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClipperPortal.Models
{
    [Table("operators")]
    public class Operator
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}