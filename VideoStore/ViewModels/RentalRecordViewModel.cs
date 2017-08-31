using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoStore.Models
{
    public class RentalRecordViewModel
    {
        public int RentalID { get; set; }
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }

        public RentalRecordViewModel()
        {
        }

        public RentalRecordViewModel(RentalRecordModel rentalRecord)
        {
            this.RentalID = rentalRecord.RentalID;
            this.MovieID = rentalRecord.MovieID;
            this.MovieName = rentalRecord.MovieModel.MovieName;
            this.RentalDate = rentalRecord.RentalDate;
            this.DueDate = rentalRecord.DueDate;
            this.ReturnDate = rentalRecord.ReturnDate;
            this.CustomerID = rentalRecord.CustomerID;
            this.CustomerName = rentalRecord.CustomerModel.CustomerName;
            this.CustomerPhoneNumber = rentalRecord.CustomerModel.CustomerPhoneNumber;
        }
    }
}