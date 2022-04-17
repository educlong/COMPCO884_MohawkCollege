using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace midterm.Models
{
    [Table("nursing_units")]
    public partial class NursingUnit
    {
        public NursingUnit()
        {
            Admissions = new HashSet<Admission>();
        }

        [Key]
        [Column("nursing_unit_id")]
        [StringLength(10)]
        public string NursingUnitId { get; set; }
        [Required]
        [Column("specialty")]
        [StringLength(20)]
        public string Specialty { get; set; }
        [Column("manager_first_name")]
        [StringLength(30)]
        public string ManagerFirstName { get; set; }
        [Column("manager_last_name")]
        [StringLength(30)]
        public string ManagerLastName { get; set; }
        [Column("beds")]
        public int? Beds { get; set; }
        [Column("extension")]
        public int? Extension { get; set; }

        [InverseProperty(nameof(Admission.NursingUnit))]
        public virtual ICollection<Admission> Admissions { get; set; }
    }
}
