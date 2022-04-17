using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Hospital_aspNetCoreWebApp_ModelViewControl.Models
{
    [Table("vendors")]
    public partial class Vendor
    {
        public Vendor()
        {
            Items = new HashSet<Item>();
            PurchaseOrders = new HashSet<PurchaseOrder>();
        }

        [Key]
        [Column("vendor_id")]
        public int VendorId { get; set; }
        [Required]
        [Column("vendor_name")]
        [StringLength(30)]
        public string VendorName { get; set; }
        [Column("street_address")]
        [StringLength(30)]
        public string StreetAddress { get; set; }
        [Column("city")]
        [StringLength(30)]
        public string City { get; set; }
        [Column("province_id")]
        [StringLength(2)]
        public string ProvinceId { get; set; }
        [Column("postal_code")]
        [StringLength(7)]
        public string PostalCode { get; set; }
        [Column("contact_first_name")]
        [StringLength(30)]
        public string ContactFirstName { get; set; }
        [Column("contact_last_name")]
        [StringLength(30)]
        public string ContactLastName { get; set; }
        [Column("purchases_ytd", TypeName = "decimal(9, 2)")]
        public decimal? PurchasesYtd { get; set; }

        [ForeignKey(nameof(ProvinceId))]
        [InverseProperty("Vendors")]
        public virtual Province Province { get; set; }
        [InverseProperty(nameof(Item.PrimaryVendor))]
        public virtual ICollection<Item> Items { get; set; }
        [InverseProperty(nameof(PurchaseOrder.Vendor))]
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
