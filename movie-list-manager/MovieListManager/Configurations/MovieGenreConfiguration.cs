using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieListManager.Models;

namespace MovieListManager.Configurations
{
    public class MovieGenreConfiguration : IEntityTypeConfiguration<MovieGenre>
    {
        public void Configure(EntityTypeBuilder<MovieGenre> builder)
        {
            builder.HasKey(x => new { x.MoveId, x.GenreId });

            builder
                .HasOne(x => x.Movie)
                .WithMany(x => x.MovieGenres)
                .HasForeignKey(x => x.MoveId);

            builder
                .HasOne(x => x.Genre)
                .WithMany(x => x.MovieGenres)
                .HasForeignKey(x => x.GenreId);
        }
    }
}
