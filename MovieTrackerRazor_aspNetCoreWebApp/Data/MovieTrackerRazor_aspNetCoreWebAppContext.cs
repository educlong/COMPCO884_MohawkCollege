using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieTrackerRazor_aspNetCoreWebApp.Models;

namespace MovieTrackerRazor_aspNetCoreWebApp.Data
{
    public class MovieTrackerRazor_aspNetCoreWebAppContext : DbContext
    {
        public MovieTrackerRazor_aspNetCoreWebAppContext (DbContextOptions<MovieTrackerRazor_aspNetCoreWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<MovieTrackerRazor_aspNetCoreWebApp.Models.Movie> Movie { get; set; }
    }
}
