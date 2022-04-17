using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMovieTracker_BlazorWebAssemblyApp.Shared
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [StringLength(25)]
        public string GenreDescription { get; set; }
        public int? MovieCount { get; set; }
    }
}
