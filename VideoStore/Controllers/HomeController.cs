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
    public class HomeController : Controller
    {
        private readonly VideosdbContext _context;

        public HomeController(VideosdbContext context)
        {
            _context = context;
        }

        public IActionResult Seed()
        {
            var seedGenres = new List<GenreModel>(){
                new GenreModel {
                    GenreName = "Action",

                    },
                    new GenreModel {
                    GenreName = "Horror",
                    },
                    new GenreModel {
                    GenreName = "Fantasy",
                    },
            };
            var seedMovies = new List<MovieModel>(){
                new MovieModel {
                    MovieName = "Speed",
                    MovieDescription = "Need for speed",
                    GenreID = 1
                    },
                    new MovieModel {
                    MovieName = "IT",
                    MovieDescription = "Scary clowns",
                    GenreID = 2
                    },
                    new MovieModel {
                    MovieName = "The Hobbit",
                    MovieDescription = "Small people save the world",
                    GenreID = 3
                    },
            };
            var seedCustomers = new List<CustomerModel>(){
                new CustomerModel {
                    CustomerName = "Jon Snow",
                    CustomerPhoneNumber = "555-999-1234",
                    },
                    new CustomerModel {
                    CustomerName = "Cersei Lanister",
                    CustomerPhoneNumber = "222-444-6666",
                    },
                    new CustomerModel {
                    CustomerName = "Tyrion Lanister",
                    CustomerPhoneNumber = "888-111-3333",
                    },
            };
            seedGenres.ForEach(genre => _context.Genre.Add(genre));
            seedMovies.ForEach(movie => _context.Movie.Add(movie));
            seedCustomers.ForEach(customer => _context.Customer.Add(customer));
            _context.SaveChanges();

            return Ok();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Return()
        {
            var service = new VideoStoreServices(_context);
            return View(service.GetAllRentalRecordsCurrentlyRented());
        }

        public IActionResult Overdue()
        {
            //get all rental records where movies are overdue
            var allOverdueRecords = new VideoStoreServices(_context);
            return View(allOverdueRecords.GetAllOverDueMovies());

        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
