using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VideoStore.Models;
using VideoStore.Services;

namespace VideoStore.Controllers
{
    public class RentalRecordsController : Controller
    {
        private readonly VideosdbContext _context;

        public RentalRecordsController(VideosdbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //get all rental records
            var allRecords = new VideoStoreServices(_context);
            return View(allRecords.GetAllRentalRecords());
        }

        public IActionResult Create()
        {
            //populate all customers and movies on rental form
            var newRental = new VideoStoreServices(_context);
            return View(newRental.PopulateNewRentalRecord());
        }
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

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
