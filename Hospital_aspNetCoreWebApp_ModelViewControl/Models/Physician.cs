using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Hospital_aspNetCoreWebApp_ModelViewControl.Models
{
    [Table("physicians")]
    public partial class Physician
    {
        public Physician()
        {
            Admissions = new HashSet<Admission>();
            Encounters = new HashSet<Encounter>();
        }

        [Key]
        [Column("physician_id")]
        public int PhysicianId { get; set; }
        [Column("first_name")]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Column("last_name")]
        [StringLength(30)]
        public string LastName { get; set; }
        [Column("specialty")]
        [StringLength(25)]
        public string Specialty { get; set; }
        [Column("phone")]
        [StringLength(15)]
        public string Phone { get; set; }
        [Column("ohip_registration")]
        public int? OhipRegistration { get; set; }

        [InverseProperty(nameof(Admission.AttendingPhysician))]
        public virtual ICollection<Admission> Admissions { get; set; }
        [InverseProperty(nameof(Encounter.Physician))]
        public virtual ICollection<Encounter> Encounters { get; set; }
    }
}
