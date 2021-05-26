using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealbnbDev.Models
{
    public class bnbProperties
    {
        [Key]
        public int PropertyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public string Image { get; set; }
    }
}