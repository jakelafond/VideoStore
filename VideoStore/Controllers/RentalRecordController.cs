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
    public class RentalRecordController : Controller
    {
        private readonly VideosdbContext _context;

        public RentalRecordController(VideosdbContext context)
        {
            _context = context;
        }

        // GET: RentalRecord
        public IActionResult Index()
        {
            var service = new VideoStoreServices(_context);
            return View(service.GetAllRentalRecords());
        }

        // GET: RentalRecord/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var RentalRecordViewModel = await _context.RentalRecord
                .Include(r => r.CustomerModel)
                .Include(r => r.MovieModel)
                .SingleOrDefaultAsync(m => m.RentalID == id);
            if (RentalRecordViewModel == null)
            {
                return NotFound();
            }

            return View(RentalRecordViewModel);
        }

        // GET: RentalRecord/Create
        public IActionResult Create()
        {
            var movieForm = new VideoStoreServices(_context);
            return View(movieForm.PopulateNewRentalRecord());
        }

        // POST: RentalRecord/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult CreateRecord(int movie, int customer, DateTime rentaldate, DateTime duedate)
        {
            var newRecord = new RentalRecordModel
            {
                MovieID = movie,
                CustomerID = customer,
                RentalDate = rentaldate,
                DueDate = duedate
            };
            _context.RentalRecord.Add(newRecord);
            _context.SaveChanges();

            return Redirect("Index");
        }

        // GET: RentalRecord/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var RentalRecordViewModel = await _context.RentalRecord.SingleOrDefaultAsync(m => m.RentalID == id);
            if (RentalRecordViewModel == null)
            {
                return NotFound();
            }
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "CustomerID", RentalRecordViewModel.CustomerID);
            ViewData["MovieID"] = new SelectList(_context.Movie, "MovieID", "MovieID", RentalRecordViewModel.MovieID);
            return View(RentalRecordViewModel);
        }

        // POST: RentalRecord/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieID,CustomerID,RentalDate,DueDate,ReturnDate")] RentalRecordModel RentalRecordViewModel)
        {
            if (id != RentalRecordViewModel.RentalID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(RentalRecordViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalRecordViewModelExists(RentalRecordViewModel.RentalID))
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
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "CustomerID", RentalRecordViewModel.CustomerID);
            ViewData["MovieID"] = new SelectList(_context.Movie, "MovieID", "MovieID", RentalRecordViewModel.MovieID);
            return View(RentalRecordViewModel);
        }

        // GET: RentalRecord/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var RentalRecordViewModel = await _context.RentalRecord
                .Include(r => r.CustomerModel)
                .Include(r => r.MovieModel)
                .SingleOrDefaultAsync(m => m.RentalID == id);
            if (RentalRecordViewModel == null)
            {
                return NotFound();
            }

            return View(RentalRecordViewModel);
        }

        // POST: RentalRecord/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var RentalRecordViewModel = await _context.RentalRecord.SingleOrDefaultAsync(m => m.RentalID == id);
            _context.RentalRecord.Remove(RentalRecordViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalRecordViewModelExists(int id)
        {
            return _context.RentalRecord.Any(e => e.RentalID == id);
        }
    }
}
