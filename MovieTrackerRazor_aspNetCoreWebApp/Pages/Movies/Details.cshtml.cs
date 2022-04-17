using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieTrackerRazor_aspNetCoreWebApp.Data;
using MovieTrackerRazor_aspNetCoreWebApp.Models;

namespace MovieTrackerRazor_aspNetCoreWebApp.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly MovieTrackerRazor_aspNetCoreWebApp.Data.MovieTrackerRazor_aspNetCoreWebAppContext _context;

        public DetailsModel(MovieTrackerRazor_aspNetCoreWebApp.Data.MovieTrackerRazor_aspNetCoreWebAppContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie.FirstOrDefaultAsync(m => m.Id == id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
