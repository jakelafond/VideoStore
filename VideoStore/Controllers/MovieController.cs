using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VideoStore;
using VideoStore.Models;
using VideoStore.Services;

namespace VideoStore.Controllers
{
    public class MovieController : Controller
    {
        private readonly VideosdbContext _context;

        public MovieController(VideosdbContext context)
        {
            _context = context;
        }

        // GET: Movie
        public IActionResult Index()
        {
             var allMoviesService = new VideoStoreServices(_context);
            return View(allMoviesService.GetAllMovies());
        }

        // GET: Movie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var MovieViewModel = await _context.Movie
                .Include(m => m.GenreModel)
                .SingleOrDefaultAsync(m => m.MovieID == id);
            if (MovieViewModel == null)
            {
                return NotFound();
            }

            return View(MovieViewModel);
        }

        // GET: Movie/Create
        public IActionResult Create()
        {
            ViewData["GenreID"] = new SelectList(_context.Genre, "GenreID", "GenreID");
            return View();
        }

        // POST: Movie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieID,MovieName,MovieDescription,GenreID")] MovieModel MovieModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(MovieModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(MovieModel);
        }

        // GET: Movie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var MovieModel = await _context.Movie.SingleOrDefaultAsync(m => m.MovieID == id);
            if (MovieModel == null)
            {
                return NotFound();
            }
            ViewData["GenreID"] = new SelectList(_context.Genre, "GenreID", "GenreID", MovieModel.GenreID);
            return View(MovieModel);
        }

        // POST: Movie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieID,MovieName,MovieDescription,GenreID")] MovieModel MovieViewModel)
        {
            if (id != MovieViewModel.MovieID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(MovieViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieViewModelExists(MovieViewModel.MovieID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(MovieViewModel);
        }

        // GET: Movie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var MovieViewModel = await _context.Movie
                .Include(m => m.GenreModel)
                .SingleOrDefaultAsync(m => m.MovieID == id);
            if (MovieViewModel == null)
            {
                return NotFound();
            }

            return View(MovieViewModel);
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var MovieViewModel = await _context.Movie.SingleOrDefaultAsync(m => m.MovieID == id);
            _context.Movie.Remove(MovieViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieViewModelExists(int id)
        {
            return _context.Movie.Any(e => e.MovieID == id);
        }
    }
}
