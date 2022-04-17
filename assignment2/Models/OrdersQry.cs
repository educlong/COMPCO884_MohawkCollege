using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace assignment2.Models
{
    [Keyless]
    public partial class OrdersQry
    {
        [Column("order_id")]
        public int OrderId { get; set; }
        [Column("customer_id")]
        [StringLength(5)]
        public string CustomerId { get; set; }
        [Column("employee_id")]
        public int? EmployeeId { get; set; }
        [Column("order_date", TypeName = "datetime")]
        public DateTime? OrderDate { get; set; }
        [Column("required_date", TypeName = "datetime")]
        public DateTime? RequiredDate { get; set; }
        [Column("shipped_date", TypeName = "datetime")]
        public DateTime? ShippedDate { get; set; }
        [Column("ship_via")]
        public int? ShipVia { get; set; }
        [Column("freight", TypeName = "money")]
        public decimal? Freight { get; set; }
        [Column("ship_name")]
        [StringLength(40)]
        public string ShipName { get; set; }
        [Column("ship_address")]
        [StringLength(60)]
        public string ShipAddress { get; set; }
        [Column("ship_city")]
        [StringLength(15)]
        public string ShipCity { get; set; }
        [Column("ship_region")]
        [StringLength(15)]
        public string ShipRegion { get; set; }
        [Column("ship_postal_code")]
        [StringLength(10)]
        public string ShipPostalCode { get; set; }
        [Column("ship_country")]
        [StringLength(15)]
        public string ShipCountry { get; set; }
        [Required]
        [Column("company_name")]
        [StringLength(40)]
        public string CompanyName { get; set; }
        [Column("address")]
        [StringLength(60)]
        public string Address { get; set; }
        [Column("city")]
        [StringLength(15)]
        public string City { get; set; }
        [Column("region")]
        [StringLength(15)]
        public string Region { get; set; }
        [Column("postal_code")]
        [StringLength(10)]
        public string PostalCode { get; set; }
        [Column("country")]
        [StringLength(15)]
        public string Country { get; set; }
    }
}
