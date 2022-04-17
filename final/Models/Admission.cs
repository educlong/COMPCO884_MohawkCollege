using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace final.Models
{
    [Table("admissions")]
    public partial class Admission
    {
        [Key]
        [Column("patient_id")]
        public int PatientId { get; set; }
        [Key]
        [Column("admission_date", TypeName = "date")]
        public DateTime AdmissionDate { get; set; }
        [Column("discharge_date", TypeName = "date")]
        public DateTime? DischargeDate { get; set; }
        [Column("primary_diagnosis"), Display(Name = "Diagnosis")]
        [StringLength(50)]
        public string PrimaryDiagnosis { get; set; }
        [Column("secondary_diagnoses")]
        [StringLength(240)]
        public string SecondaryDiagnoses { get; set; }
        [Column("attending_physician_id")]
        public int? AttendingPhysicianId { get; set; }
        [Column("nursing_unit_id")]
        [StringLength(10)]
        public string NursingUnitId { get; set; }
        [Column("room")]
        public int? Room { get; set; }
        [Column("bed")]
        public int? Bed { get; set; }

        [ForeignKey(nameof(AttendingPhysicianId))]
        [InverseProperty(nameof(Physician.Admissions))]
        public virtual Physician AttendingPhysician { get; set; }
        [ForeignKey(nameof(NursingUnitId))]
        [InverseProperty("Admissions"), Display(Name = "Nursing Unit")]
        public virtual NursingUnit NursingUnit { get; set; }
        [ForeignKey(nameof(PatientId))]
        [InverseProperty("Admissions")]
        public virtual Patient Patient { get; set; }
    }
}
