using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JINI.Models
{
    public class SalesOrderItem
    {
        public int ID { get; set; }

        [Display(Name = "거래일자")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public string SalesDate { get; set; }

        [Display(Name = "단가")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal UnitCost { get; set; }

        [Display(Name = "단위이익")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal UnitProfit { get; set; }

        [Display(Name = "주문수량")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 1)")]
        public decimal SalesQuantity { get; set; }

        [Display(Name = "품번")]
        public string ItemNumber { get; set; }

        [Display(Name = "색상")]
        public string ItemColor { get; set; }

        [Display(Name = "비고")]
        public string Comment { get; set; }

        [Display(Name = "거래명세서")]
        public SalesOrder SalesOrder { get; set; }

        [Display(Name = "품명")]
        public Item Item { get; set; }


    }
}
