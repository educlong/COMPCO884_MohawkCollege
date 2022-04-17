using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace midterm.Models
{
    [Table("provinces")]
    public partial class Province
    {
        public Province()
        {
            Patients = new HashSet<Patient>();
            Vendors = new HashSet<Vendor>();
        }

        [Key]
        [Column("province_id")]
        [StringLength(2)]
        public string ProvinceId { get; set; }
        [Required]
        [Column("province_name")]
        [StringLength(30)]
        public string ProvinceName { get; set; }

        [InverseProperty(nameof(Patient.Province))]
        public virtual ICollection<Patient> Patients { get; set; }
        [InverseProperty(nameof(Vendor.Province))]
        public virtual ICollection<Vendor> Vendors { get; set; }
    }
}
