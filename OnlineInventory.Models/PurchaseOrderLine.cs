using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.Models
{
    public class PurchaseOrderLine
    {
        public int Id { get; set; }
        [Display(Name= "Purchase Order")]
        public int PurchaseOrderId { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }
        [Display(Name = "Product")]
        public int ProductId { get; set; }
        public string Description { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
        [Display(Name = "Discount")]
        public double DiscountPercentage { get; set; }
        public double DiscountAmount { get; set;}
        public double SubTotal { get; set; }
        public double TaxPercentage { get; set; }
        public double TaxAmount { get; set;}
        public double Total { get; set; }
    }
}
