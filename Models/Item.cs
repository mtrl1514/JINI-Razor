using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JINI.Models
{
    public class Item
    {
        public int ID { get; set; }

        [Required]
        public string Supplier { get; set; }
        public string Address { get; set; }

        [Display(Name = "Contact Number"), DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        public string Name { get; set; }


    }
}
