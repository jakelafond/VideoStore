using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoStore.Models
{
    public class RentalRecordViewModel
    {
        public List<MovieModel> Movies { get; set; }
        public DateTime RentalDate { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; } = DateTime.Now.AddDays(5);
        public List<CustomerModel> Customers { get; set; }
        public RentalRecordViewModel()
        {
        }

        public RentalRecordViewModel(RentalRecordModel rentalRecord)
        {
            this.Customers = new List<CustomerModel>();
            this.Movies = new List<MovieModel>();
        }
    }
}