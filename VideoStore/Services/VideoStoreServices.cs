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
        public CheckOutViewModel PopulateNewRentalRecord()
        {
            //get all users
            var customerInfo = _context.Customer;
            //get all movies
            var movieInfo = _context.Movie;
            //construct view model
            var newRecord = new CheckOutViewModel
            {
                Customers = customerInfo.ToList(),
                Movies = movieInfo.ToList()
            };
            return newRecord;
        }
        public IEnumerable<RentalRecordViewModel> GetAllRentalRecords()
        {
            //get all users
            var customerInfo = _context.Customer;
            //get all movies
            var movieInfo = _context.Movie;
            //construct rental view model
            var allRecords = _context.RentalRecord;
            return allRecords.Include(m => m.MovieModel).Include(c => c.CustomerModel).Select(s => new RentalRecordViewModel(s));
        }

        public IEnumerable<RentalRecordViewModel> GetAllOverDueMovies()
        {
            //get all users
            var customerInfo = _context.Customer;
            //get all movies
            var movieInfo = _context.Movie;
            //construct rental view model
            var allRecords = _context.RentalRecord;
            var today = DateTime.Today;
            return allRecords.Where(t => t.DueDate.CompareTo(today)<0).Include(m => m.MovieModel).Include(c => c.CustomerModel).Select(s => new RentalRecordViewModel(s));

        }

    }
}
