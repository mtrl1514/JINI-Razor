using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JINI.Models
{
    public class Customer
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "고객명")]
        public string Name { get; set; }
        [Display(Name = "대표자")]
        public string Owner { get; set; }
        
    }
}
