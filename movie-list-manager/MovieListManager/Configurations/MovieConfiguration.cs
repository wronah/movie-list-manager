using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieListManager.Models;

namespace MovieListManager.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).HasMaxLength(128);
            builder.Property(x => x.Director).HasMaxLength(128);
            builder.Property(x => x.Notes).HasMaxLength(255);
        }
    }
}
