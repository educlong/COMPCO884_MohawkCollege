using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace assignment2.Models
{
    [Keyless]
    public partial class AlphabeticalListOfProduct
    {
        [Column("product_id")]
        public int ProductId { get; set; }
        [Required]
        [Column("product_name")]
        [StringLength(40)]
        public string ProductName { get; set; }
        [Column("supplier_id")]
        public int? SupplierId { get; set; }
        [Column("category_id")]
        public int? CategoryId { get; set; }
        [Column("quantity_per_unit")]
        [StringLength(20)]
        public string QuantityPerUnit { get; set; }
        [Column("unit_price", TypeName = "money")]
        public decimal? UnitPrice { get; set; }
        [Column("units_in_stock")]
        public short? UnitsInStock { get; set; }
        [Column("units_on_order")]
        public short? UnitsOnOrder { get; set; }
        [Column("reorder_level")]
        public short? ReorderLevel { get; set; }
        [Column("discontinued")]
        public bool Discontinued { get; set; }
        [Required]
        [Column("category_name")]
        [StringLength(15)]
        public string CategoryName { get; set; }
    }
}
