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

        [Display(Name = "매출일자")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public string RevenueDate { get; set; }

        [Display(Name = "결제금액")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal RevenueCost { get; set; }

        [Display(Name = "거래명세서")]
        public SalesOrder SalesOrder { get; set; }
    }
}
