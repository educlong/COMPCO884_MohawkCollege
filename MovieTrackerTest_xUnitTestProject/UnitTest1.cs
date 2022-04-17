using MovieTracker_aspNetCoreWebApp_MVC.Data;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using MovieTracker_aspNetCoreWebApp_MVC.Models;
using MovieTracker_aspNetCoreWebApp_MVC.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MovieTrackerTest_xUnitTestProject
{
    public class UnitTest1
    {
        private MovieTracker_aspNetCoreWebApp_MVCContext CreateContext (string databaseName)
        {
            var context = new MovieTracker_aspNetCoreWebApp_MVCContext(
                new DbContextOptionsBuilder<MovieTracker_aspNetCoreWebApp_MVCContext>().UseInMemoryDatabase(
                    databaseName: databaseName).Options);
            context.Movie.AddRange(
                new Movie
                {
                    Id = 1,
                    Title="Toy Story",
                    DateSeen = new DateTime(2021, 11, 15).Date,
                    GenreId = 4,
                    Rating=6
                },
                new Movie
                {
                    Id = 2,
                    Title="Toy Story 2",
                    DateSeen = new DateTime(2021, 10, 15).Date,
                    GenreId = 1,
                    Rating=7
                },
                new Movie
                {
                    Id = 3,
                    Title="Toy Story 3",
                    DateSeen = new DateTime(2021, 09, 16).Date,
                    GenreId = 9,
                    Rating=8
                }
            );
            context.SaveChanges();
            return context;
        }
        [Fact]
        public async Task Index_NoInput_ReturnsMovies()
        {
            //Arrange
            var moviesController = new MoviesController(CreateContext("Index"));
            //Act
            var actionResult = await moviesController.Index();
            //Assert
            Assert.IsType<ViewResult>(actionResult);
            Assert.IsType<List<Movie>>((actionResult as ViewResult).Model);
            var movies = (actionResult as ViewResult).Model as List<Movie>;
            //Check the number of movies and a portion of every record and all properties
            Assert.Equal(3, movies.Count);
            Assert.Equal(1, movies[0].Id);
            Assert.Equal("Toy Story 2", movies[1].Title);
            Assert.Equal(new DateTime(2021, 09, 16).Date, movies[2].DateSeen);  //stuff like that, test all the properties for 3 movies
        }
        [Fact]
        public async Task Details_MovieId_ReturnsMovie()
        {
            //Arrange
            var moviesController = new MoviesController(CreateContext("Detail"));
            //Act
            var actionResult = await moviesController.Details(1);
            //Assert
            Assert.IsType<ViewResult>(actionResult);
            Assert.IsType<Movie>((actionResult as ViewResult).Model);
            var movie = (actionResult as ViewResult).Model as Movie;
            //Test all properties
            Assert.Equal(1, movie.Id);
            Assert.Equal("Toy Story", movie.Title);
            Assert.Equal(new DateTime(2021, 11, 15).Date, movie.DateSeen);
            Assert.Equal(4, movie.GenreId);
            Assert.Equal(6, movie.Rating);
        }
        [Fact]
        public async Task Create_Movie_RedirectsToIndex()
        {
            //Arrange
            var moviesController = new MoviesController(CreateContext("Create"));
            //Act
            var actionResult = await moviesController.Create(new Movie
            {
                Title = "Toy Story 4",
                DateSeen = DateTime.Now.Date,
                GenreId = 11,
                Rating = 9
            });
            //Assert
            Assert.IsType<RedirectToActionResult>(actionResult);
            Assert.Equal("Index", (actionResult as RedirectToActionResult).ActionName);
            //verify count
            var movies = ((await moviesController.Index()) as ViewResult).Model as List<Movie>;
            Assert.Equal(4, movies.Count);
        }

    }
}
