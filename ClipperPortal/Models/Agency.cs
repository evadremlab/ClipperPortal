using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClipperPortal.Models
{
    [Table("agencies")]
    public class Agency
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}