using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace assignment2.Models
{
    [Keyless]
    public partial class SalesByCategory
    {
        [Column("category_id")]
        public int CategoryId { get; set; }
        [Required]
        [Column("category_name")]
        [StringLength(15)]
        public string CategoryName { get; set; }
        [Required]
        [Column("product_name")]
        [StringLength(40)]
        public string ProductName { get; set; }
        [Column("product_sales", TypeName = "money")]
        public decimal? ProductSales { get; set; }
    }
}
