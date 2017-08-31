namespace VideoStore.Models
{
    public class MovieViewModel
    {
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public string MovieDescription { get; set; }
        public string GenreName { get; set; }
        public MovieViewModel()
        {
        }

        public MovieViewModel(MovieModel movie)
        {
            this.MovieName = movie.MovieName;
            this.MovieDescription = movie.MovieDescription;
            this.GenreName = movie.GenreModel?.GenreName;
            this.MovieID = movie.MovieID;

        }
    }
}