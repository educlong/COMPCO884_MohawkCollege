using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace midterm.Models
{
    [Table("purchase_orders")]
    public partial class PurchaseOrder
    {
        public PurchaseOrder()
        {
            PurchaseOrderLines = new HashSet<PurchaseOrderLine>();
        }

        [Key]
        [Column("purchase_order_id")]
        public int PurchaseOrderId { get; set; }
        [Column("order_date", TypeName = "date"), Display(Name = "Order Date"), DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        [Column("department_id")]
        public int? DepartmentId { get; set; }
        [Column("vendor_id"), Display(Name ="Vendor Id")]
        public int? VendorId { get; set; }
        [Column("total_amount", TypeName = "decimal(9, 2)"), Display(Name = "Total Amount")]
        public decimal? TotalAmount { get; set; }
        [Column("order_status")]
        [StringLength(10)]
        public string OrderStatus { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty("PurchaseOrders")]
        public virtual Department Department { get; set; }
        [ForeignKey(nameof(VendorId))]
        [InverseProperty("PurchaseOrders")]
        public virtual Vendor Vendor { get; set; }
        [InverseProperty(nameof(PurchaseOrderLine.PurchaseOrder))]
        public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; }
    }
}
