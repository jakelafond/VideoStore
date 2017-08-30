using System;
using System.ComponentModel.DataAnnotations;

namespace VideoStore.Models
{
    public class GenreModel
    {
        [Key]
        public int GenreID { get; set; }

        public string GenreName { get; set; }
    }
}