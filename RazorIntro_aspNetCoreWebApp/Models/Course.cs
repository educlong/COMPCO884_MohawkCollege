using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorIntro_aspNetCoreWebApp.Models
{
    public class Course
    {
        [Display(Name = "Course Code")]
        public string  CourseCode { get; set; }
    
        [Display(Name = "Course Name")]
        public string  CourseName { get; set; }
    
        public int? Hours { get; set; }
    }
}
