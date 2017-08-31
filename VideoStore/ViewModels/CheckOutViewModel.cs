using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoStore.Models
{
    public class CheckOutViewModel
    {
        public List<MovieModel> Movies { get; set; }
        public DateTime RentalDate { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; } = DateTime.Now.AddDays(5);
        public List<CustomerModel> Customers { get; set; }
        public CheckOutViewModel()
        {
        }

        public CheckOutViewModel(RentalRecordModel rentalRecord)
        {
            this.Customers = new List<CustomerModel>();
            this.Movies = new List<MovieModel>();
        }
    }
}