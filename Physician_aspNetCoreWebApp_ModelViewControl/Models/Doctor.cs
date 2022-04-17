using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Physician_aspNetCoreWebApp_ModelViewControl.Models
{

    public class Doctor
    {
        [Key]
        public int physicianId { get; set; }
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Display(Name = "Specialty")]
        public string specialty { get; set; }
        [Display(Name = "Phone")]
        public string phone { get; set; }
        [Display(Name = "OHIP Registration")]
        public int ohipRegistration { get; set; }
    }

}
