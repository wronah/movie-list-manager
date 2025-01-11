using System.ComponentModel.DataAnnotations;

namespace MovieListManager.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        [Range(1, 10)]
        public int Rating { get; set; }

        // user ID from AspNetUser table.
        public string? OwnerId { get; set; }
    }
}
