using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTracker_aspNetCoreWebApp_MVC.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [StringLength(25)]
        public string GenreDescription { get; set; }
        //Navigation property
        public List<Movie> Movies { get; set; }
    }
}
