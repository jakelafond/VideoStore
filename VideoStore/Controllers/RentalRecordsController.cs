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
            var service = new VideoStoreServices(_context);
            return View(service.GetAllMovies());
        }

        public IActionResult Create(int id)
        {
            

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
