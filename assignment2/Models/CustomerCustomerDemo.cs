using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace assignment2.Models
{
    [Table("customer_customer_demo")]
    public partial class CustomerCustomerDemo
    {
        [Key]
        [Column("customer_id")]
        [StringLength(5)]
        public string CustomerId { get; set; }
        [Key]
        [Column("customer_type_id")]
        [StringLength(10)]
        public string CustomerTypeId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("CustomerCustomerDemos")]
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(CustomerTypeId))]
        [InverseProperty(nameof(CustomerDemographic.CustomerCustomerDemos))]
        public virtual CustomerDemographic CustomerType { get; set; }
    }
}
