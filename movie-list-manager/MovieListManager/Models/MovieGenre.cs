namespace MovieListManager.Models
{
    public class MovieGenre
    {
        public int MoveId { get; set; }
        public Movie? Movie { get; set; }

        public int GenreId { get; set; }
        public Genre? Genre { get; set; }
    }
}
