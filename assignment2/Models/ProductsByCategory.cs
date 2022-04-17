using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace assignment2.Models
{
    [Keyless]
    public partial class ProductsByCategory
    {
        [Required]
        [Column("category_name")]
        [StringLength(15)]
        public string CategoryName { get; set; }
        [Required]
        [Column("product_name")]
        [StringLength(40)]
        public string ProductName { get; set; }
        [Column("quantity_per_unit")]
        [StringLength(20)]
        public string QuantityPerUnit { get; set; }
        [Column("units_in_stock")]
        public short? UnitsInStock { get; set; }
        [Column("discontinued")]
        public bool Discontinued { get; set; }
    }
}
