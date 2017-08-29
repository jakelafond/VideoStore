using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoStore.Models
{
    public class MovieModel
    {
        [Key]
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public string MovieDescription { get; set; }
        
        [ForeignKey("GenreID")]
        public int GenreID { get; set; }
        public GenreModel GenreModel {get;set;}
    }
}