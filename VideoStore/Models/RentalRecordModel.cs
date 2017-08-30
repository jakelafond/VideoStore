using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoStore.Models
{
    public class RentalRecordModel
    {
        [Key]
        public int RentalID { get; set; }
        [ForeignKey("MovieID")]
        public int MovieID { get; set; }
        public MovieModel MovieModel { get; set; }
        [ForeignKey("CustomerID")]
        public int CustomerID { get; set; }
        public CustomerModel CustomerModel { get; set; }
        public DateTime RentalDate { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; } = DateTime.Now.AddDays(5);
        public DateTime ReturnDate { get; set; }

    }
}