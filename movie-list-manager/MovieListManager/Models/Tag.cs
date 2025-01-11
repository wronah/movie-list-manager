namespace MovieListManager.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public IList<MovieTag>? MovieTags { get; set; }
    }
}
