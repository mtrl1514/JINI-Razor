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

        [Display(Name = "Sales Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public string SalesDate { get; set; }
        
        [Display(Name = "Unit Cost"), DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal UnitCost { get; set; }

        [Display(Name = "Unit Profit"), DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal UnitProfit { get; set; }

        [Display(Name = "Sales Quantity"), DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 1)")]
        public decimal SalesQuantity { get; set; }

        [Display(Name = "Item Number")]
        public string ItemNumber { get; set; }

        [Display(Name = "Item Color")]
        public string ItemColor { get; set; }
        public string Comment { get; set; }

        public SalesOrder SalesOrder { get; set; }
        public Item Item { get; set; }


    }
}
