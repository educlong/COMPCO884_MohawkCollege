using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace assignment2.Models
{
    [Keyless]
    public partial class SalesTotalsByAmount
    {
        [Column("sale_amount", TypeName = "money")]
        public decimal? SaleAmount { get; set; }
        [Column("order_id")]
        public int OrderId { get; set; }
        [Required]
        [Column("company_name")]
        [StringLength(40)]
        public string CompanyName { get; set; }
        [Column("shipped_date", TypeName = "datetime")]
        public DateTime? ShippedDate { get; set; }
    }
}
