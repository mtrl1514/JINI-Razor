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
        [Display(Name = "사입가게")]
        public string Supplier { get; set; }
        [Display(Name = "주소")]
        public string Address { get; set; }

        [Display(Name = "연락처")]
        [DataType(DataType.PhoneNumber)]
        public string ContactNumber { get; set; }

        [Required]
        [Display(Name = "제품명")]
        public string ItemName { get; set; }


    }
}
