using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace assignment2.Models
{
    [Keyless]
    public partial class QuarterlyOrder
    {
        [Column("customer_id")]
        [StringLength(5)]
        public string CustomerId { get; set; }
        [Column("company_name")]
        [StringLength(40)]
        public string CompanyName { get; set; }
        [Column("city")]
        [StringLength(15)]
        public string City { get; set; }
        [Column("country")]
        [StringLength(15)]
        public string Country { get; set; }
    }
}
