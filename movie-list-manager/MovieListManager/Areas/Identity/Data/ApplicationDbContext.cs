using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieListManager.Models;
using MovieListManager.Views.Movies;

namespace MovieListManager.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<MovieGenre> MovieGenres { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<MovieTag> MovieTags { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<MovieGenre>().HasKey(x => new { x.MovieId, x.GenreId});
        builder.Entity<MovieTag>().HasKey(x => new { x.MovieId, x.TagId});
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

public DbSet<MovieListManager.Views.Movies.CrudMovie> CrudMovie { get; set; } = default!;
}
