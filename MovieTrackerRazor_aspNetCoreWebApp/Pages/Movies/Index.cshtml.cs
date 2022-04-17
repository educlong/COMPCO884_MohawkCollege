using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieTrackerRazor_aspNetCoreWebApp.Data;
using MovieTrackerRazor_aspNetCoreWebApp.Models;

namespace MovieTrackerRazor_aspNetCoreWebApp.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly MovieTrackerRazor_aspNetCoreWebApp.Data.MovieTrackerRazor_aspNetCoreWebAppContext _context;

        public IndexModel(MovieTrackerRazor_aspNetCoreWebApp.Data.MovieTrackerRazor_aspNetCoreWebAppContext context)
        {
            _context = context;
            if (!_context.Movie.Any())
                SeedData.Initialize(_context);
        }

        public IList<Movie> Movie { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string  MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            //Use LINQ to get a list of genres
            IQueryable<string> genreQurey = from _movies in _context.Movie orderby _movies.Genre select _movies.Genre;
            Genres = new SelectList(await genreQurey.Distinct().ToListAsync());
            var movies = from _movies in _context.Movie select _movies;
            if (!string.IsNullOrEmpty(SearchString))
                movies = movies.Where(_movies => _movies.Title.Contains(SearchString));
            if (!string.IsNullOrEmpty(MovieGenre))
                movies = movies.Where(_movies => _movies.Genre == MovieGenre);
            Movie = await movies.AsNoTracking().ToListAsync();
        }
    }
}
