﻿using System.ComponentModel.DataAnnotations;

namespace MovieListManager.Views.Movies
{
    public class CrudMovie
    {
        public int Id { get; set; }
        // user ID from AspNetUser table.
        public string OwnerId { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public int ReleaseYear { get; set; }
        public string Director { get; set; } = string.Empty;
        [Range(1, 10)]
        public int Rating { get; set; }
        public DateOnly WatchedDate { get; set; }
        public string Notes { get; set; } = string.Empty;

        public IEnumerable<int>? GenreIds { get; set; }
        public IEnumerable<int>? TagIds { get; set; }
    }
}
