using System;
using System.Collections.Generic;

#nullable disable

namespace Medications_aspNetCoreWebAPI.Models
{
    public partial class Medication
    {
        public int MedicationId { get; set; }
        public string MedicationDescription { get; set; }
        public decimal? MedicationCost { get; set; }
        public string PackageSize { get; set; }
        public string Strength { get; set; }
        public string Sig { get; set; }
        public int? UnitsUsedYtd { get; set; }
        public DateTime? LastPrescribedDate { get; set; }
    }
}
