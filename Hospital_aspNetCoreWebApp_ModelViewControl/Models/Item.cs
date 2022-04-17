using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Hospital_aspNetCoreWebApp_ModelViewControl.Models
{
    [Table("items")]
    public partial class Item
    {
        public Item()
        {
            PurchaseOrderLines = new HashSet<PurchaseOrderLine>();
        }

        [Key]
        [Column("item_id")]
        public int ItemId { get; set; }
        [Required]
        [Column("item_description")]
        [StringLength(30)]
        public string ItemDescription { get; set; }
        [Column("item_cost", TypeName = "decimal(9, 2)")]
        public decimal? ItemCost { get; set; }
        [Column("quantity_on_hand")]
        public int? QuantityOnHand { get; set; }
        [Column("usage_ytd")]
        public int? UsageYtd { get; set; }
        [Column("primary_vendor_id")]
        public int? PrimaryVendorId { get; set; }
        [Column("order_quantity")]
        public int? OrderQuantity { get; set; }
        [Column("order_point")]
        public int? OrderPoint { get; set; }

        [ForeignKey(nameof(PrimaryVendorId))]
        [InverseProperty(nameof(Vendor.Items))]
        public virtual Vendor PrimaryVendor { get; set; }
        [InverseProperty(nameof(PurchaseOrderLine.Item))]
        public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; }
    }
}
