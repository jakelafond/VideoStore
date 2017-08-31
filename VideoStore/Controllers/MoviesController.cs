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
    public class MoviesController : Controller
    {
        private readonly VideosdbContext _context;

        public MoviesController(VideosdbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var service = new VideoStoreServices(_context);
            return View(service.GetAllMovies());

        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

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
