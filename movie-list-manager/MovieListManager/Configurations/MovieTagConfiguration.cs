using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieListManager.Models;

namespace MovieListManager.Configurations
{
    public class MovieTagConfiguration : IEntityTypeConfiguration<MovieTag>
    {
        public void Configure(EntityTypeBuilder<MovieTag> builder)
        {
            builder.HasKey(x => new { x.MovieId, x.TagId });

            builder
                .HasOne(x => x.Movie)
                .WithMany(x => x.MovieTags)
                .HasForeignKey(x => x.MovieId);

            builder
                .HasOne(x => x.Tag)
                .WithMany(x => x.MovieTags)
                .HasForeignKey(x => x.TagId);
        }
    }
}
