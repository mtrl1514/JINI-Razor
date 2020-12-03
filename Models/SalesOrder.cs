using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JINI.Models
{
    public class SalesOrder
    {
        public int ID { get; set; }
        [Required]        
        public string SalesOrderNo { get; set; }

        [Display(Name = "Sales Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]        
        [DataType(DataType.Date)]
        public string SalesDate { get; set; }

        [Required]
        public Customer Customer { get; set; }
        public ICollection<SalesOrderItem> SalesOrderItems { get; set; }


    }
}
