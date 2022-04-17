using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace assignment2.Models
{
    [Keyless]
    public partial class SummaryOfSalesByYear
    {
        [Column("shipped_date", TypeName = "datetime")]
        public DateTime? ShippedDate { get; set; }
        [Column("order_id")]
        public int OrderId { get; set; }
        [Column("sub_total", TypeName = "money")]
        public decimal? SubTotal { get; set; }
    }
}
