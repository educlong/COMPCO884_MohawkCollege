using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace assignment2.Models
{
    [Keyless]
    public partial class CategorySalesFor2019
    {
        [Required]
        [Column("category_name")]
        [StringLength(15)]
        public string CategoryName { get; set; }
        [Column("category_sales", TypeName = "money")]
        public decimal? CategorySales { get; set; }
    }
}
