using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTrackerRazor_aspNetCoreWebApp.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Title { get; set; }
        [DataType(DataType.Date), Display(Name = "Date Seen")]
        public DateTime? DateSeen { get; set; }
        //Navigation property
        public string Genre { get; set; }
        [Range(1, 10)]
        public int? Rating { get; set; }
        [Display(Name = "Image File")]
        public string ImageFile { get; set; }
    }
}