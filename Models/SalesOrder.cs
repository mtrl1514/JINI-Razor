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
        [Display(Name = "거래명세서 번호")]
        public string SalesOrderNo { get; set; }

        [Display(Name = "거래일자")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]        
        [DataType(DataType.Date)]
        public string SalesDate { get; set; }

        [Required]
        [Display(Name = "고객")]
        public Customer Customer { get; set; }

        [Display(Name = "거래명세 상세")]
        public ICollection<SalesOrderItem> SalesOrderItems { get; set; }


    }
}
