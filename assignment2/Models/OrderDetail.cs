using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace assignment2.Models
{
    [Table("order_details")]
    [Index(nameof(OrderId), Name = "order_id")]
    [Index(nameof(OrderId), Name = "orders_order_details")]
    [Index(nameof(ProductId), Name = "product_id")]
    [Index(nameof(ProductId), Name = "products_order_details")]
    public partial class OrderDetail
    {
        [Key]
        [Column("order_id")]
        public int OrderId { get; set; }
        [Key]
        [Column("product_id")]
        public int ProductId { get; set; }
        [Column("unit_price", TypeName = "money")]
        public decimal UnitPrice { get; set; }
        [Column("quantity")]
        public short Quantity { get; set; }
        [Column("discount")]
        public float Discount { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty("OrderDetails")]
        public virtual Order Order { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty("OrderDetails")]
        public virtual Product Product { get; set; }
    }
}
