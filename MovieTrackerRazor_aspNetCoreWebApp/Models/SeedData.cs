using MovieTrackerRazor_aspNetCoreWebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTrackerRazor_aspNetCoreWebApp.Models
{
    public static class SeedData
    {
        public static void Initialize(MovieTrackerRazor_aspNetCoreWebAppContext context) 
        {
            context.Movie.AddRange(
                   new Movie
                   {
                       Title = "Toy Story",
                       DateSeen = new DateTime(2021, 11, 15).Date,
                       Genre = "Catoon",
                       Rating = 6,
                       ImageFile = "toyStory.png"
                   },
                   new Movie
                   {
                       Title = "Toy Story 2",
                       DateSeen = new DateTime(2021, 10, 15).Date,
                       Genre = "Anime",
                       Rating = 7,
                       ImageFile = "toyStory2.png"
                   },
                   new Movie
                   {
                       Title = "Toy Story 3",
                       DateSeen = new DateTime(2021, 09, 16).Date,
                       Genre = "Adventure",
                       Rating = 8,
                       ImageFile = "toyStory3.png"
                   },
                   new Movie
                   {
                       Title = "Toy Story 4",
                       DateSeen = DateTime.Now.AddDays(-250).Date,
                       Genre = "Action",
                       Rating = 9,
                       ImageFile = "toyStory4.png"
                   }
               );
            context.SaveChanges();
        }
    }
}
