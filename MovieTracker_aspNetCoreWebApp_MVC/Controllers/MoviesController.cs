using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieTracker_aspNetCoreWebApp_MVC.Data;
using MovieTracker_aspNetCoreWebApp_MVC.Models;

namespace MovieTracker_aspNetCoreWebApp_MVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieTracker_aspNetCoreWebApp_MVCContext _context;

        public MoviesController(MovieTracker_aspNetCoreWebApp_MVCContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movie.Include(movie => movie.Genre).ToListAsync());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return View("Error",new ErrorViewModel { Description="Movie id invalid."});
            }

            var movie = await _context.Movie.Include(movie => movie.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return View("Error", new ErrorViewModel { Description = $"Unable to find movie with id={id.ToString()}" });
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            ViewBag.GenreId = GenreSelectList();
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,DateSeen,GenreId,Rating,ReleaseYear")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View("Error", new ErrorViewModel { Description = "Movie id invalid." });
            }

            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return View("Error", new ErrorViewModel { Description = $"Unable to find movie with id={id.ToString()}" });
            }
            ViewBag.GenreId = GenreSelectList();
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,DateSeen,GenreId,Rating,ReleaseYear")] Movie movie)
        {
            if (id != movie.Id)
            {
                return View("Error", new ErrorViewModel { Description = $"Movie ids don't match, id={id} not equal to Movie.id={movie.Id}." });
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return View("Error", new ErrorViewModel { Description = $"Unable to find movie with id={movie.Id.ToString()}" });
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return View("Error", new ErrorViewModel { Description = "Movie id invalid." });
            }

            var movie = await _context.Movie.Include(movie => movie.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return View("Error", new ErrorViewModel { Description = $"Unable to find movie with id={id.ToString()}" });
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
        private SelectList GenreSelectList() => new SelectList(_context.Genres, "Id", "GenreDescription");
    }
}
