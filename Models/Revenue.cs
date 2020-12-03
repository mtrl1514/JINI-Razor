using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JINI.Models
{
    public class Revenue
    {
        public int ID { get; set; }

        [Display(Name = "Revenue Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public string RevenueDate { get; set; }

        [Display(Name = "Revenue Cost"), DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal RevenueCost { get; set; }

        public SalesOrder SalesOrder { get; set; }
    }
}
