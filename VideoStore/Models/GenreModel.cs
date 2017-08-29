using System;
using System.ComponentModel.DataAnnotations;

namespace VideoStore.Models
{
    public class GenreModel
    {
        [Key]
        public string GenreID { get; set; }

        public string GenreName { get; set; }
    }
}