using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace assignment2.Models
{
    [Keyless]
    public partial class OrderDetailsExtended
    {
        [Column("order_id")]
        public int OrderId { get; set; }
        [Column("product_id")]
        public int ProductId { get; set; }
        [Required]
        [Column("product_name")]
        [StringLength(40)]
        public string ProductName { get; set; }
        [Column("unit_price", TypeName = "money")]
        public decimal UnitPrice { get; set; }
        [Column("quantity")]
        public short Quantity { get; set; }
        [Column("discount")]
        public float Discount { get; set; }
        [Column("extended_price", TypeName = "money")]
        public decimal? ExtendedPrice { get; set; }
    }
}
