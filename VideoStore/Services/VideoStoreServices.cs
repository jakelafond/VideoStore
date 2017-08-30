using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoStore.Models;

namespace VideoStore.Services
{
    public class VideoStoreServices
    {
        private readonly VideosdbContext _context;

        public VideoStoreServices(VideosdbContext context)
        {
            _context = context;
        }

        public IEnumerable<MovieViewModel> GetAllMovies()
        {
            var currentMovies = _context.Movie;
            return currentMovies.Include(i => i.GenreModel).Select(s => new MovieViewModel(s));
        }

        public RentalRecordViewModel PopulateNewRentalRecord()
        {
            //get all users
            var customerInfo = _context.Customer;
            //get all movies
            var movieInfo = _context.Movie;
            //construct view model
            var newRecord = new RentalRecordViewModel{
            Customers = customerInfo.ToList(),
            Movies = movieInfo.ToList()
            };
            

            return newRecord;
            
        }

    }
}
