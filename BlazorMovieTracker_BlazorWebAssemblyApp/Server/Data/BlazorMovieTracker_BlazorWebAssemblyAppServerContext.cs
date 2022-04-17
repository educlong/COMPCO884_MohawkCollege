using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorMovieTracker_BlazorWebAssemblyApp.Shared;

namespace BlazorMovieTracker_BlazorWebAssemblyApp.Server.Data
{
    public class BlazorMovieTracker_BlazorWebAssemblyAppServerContext : DbContext
    {
        public BlazorMovieTracker_BlazorWebAssemblyAppServerContext (DbContextOptions<BlazorMovieTracker_BlazorWebAssemblyAppServerContext> options)
            : base(options)
        {
        }

        public DbSet<BlazorMovieTracker_BlazorWebAssemblyApp.Shared.Genre> Genre { get; set; }

        public DbSet<BlazorMovieTracker_BlazorWebAssemblyApp.Shared.Movie> Movie { get; set; }
    }
}
