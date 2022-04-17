using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace assignment2.Models
{
    [Keyless]
    public partial class CustomerAndSuppliersByCity
    {
        [Column("city")]
        [StringLength(15)]
        public string City { get; set; }
        [Required]
        [Column("company_name")]
        [StringLength(40)]
        public string CompanyName { get; set; }
        [Column("contact_name")]
        [StringLength(30)]
        public string ContactName { get; set; }
        [Required]
        [Column("relationship")]
        [StringLength(9)]
        public string Relationship { get; set; }
    }
}
