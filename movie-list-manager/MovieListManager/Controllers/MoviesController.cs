using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieListManager.Areas.Identity.Data;
using MovieListManager.Authorization;
using MovieListManager.Models;
using MovieListManager.Views.Movies;
using System.Security.Claims;

namespace MovieListManager.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public MoviesController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        // GET: MoviesController
        public async Task<IActionResult> Index()
        {
            var userMovies = new List<Movie>();
            var movies = await context.Movies.ToListAsync();

            var isAdmin = User.IsInRole(ConstantRoles.Administrator);

            var currentUserId = userManager.GetUserId(User);

            // Only movies you are owner of are shown
            if (!isAdmin)
            {
                userMovies = movies.Where(c => c.OwnerId == currentUserId).ToList();
                return View(userMovies);
            }

            userMovies = movies;
            return View(userMovies);
        }

        // GET: MoviesController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = context.Movies
                .Include(x => x.MovieGenres)
                .Include(x => x.MovieTags)
                .First(x => x.Id == id);

            var viewBagGenres = new List<Genre>();
            foreach(var genreId in movieDetails.MovieGenres!.Select(x => x.GenreId))
            {
                viewBagGenres.Add(context.Genres.First(x => x.Id == genreId));
            }

            var viewBagTags = new List<Tag>();
            foreach (var tagId in movieDetails.MovieTags!.Select(x => x.TagId))
            {
                viewBagTags.Add(context.Tags.First(x => x.Id == tagId));
            }

            ViewBag.Genres = viewBagGenres;
            ViewBag.Tags = viewBagTags;

            return View(movieDetails);
        }

        // GET: MoviesController/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Genres = await context.Genres.ToListAsync();
            ViewBag.Tags = await context.Tags.ToListAsync();
            return View();
        }

        // POST: MoviesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CrudMovie movie)
        {
            var movieToAdd = new Movie()
            {
                OwnerId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                Title = movie.Title,
                ReleaseYear = movie.ReleaseYear,
                Director = movie.Director,
                Rating = movie.Rating,
                WatchedDate = movie.WatchedDate,
                Notes = movie.Notes,
            };

            var addedMovie = await context.Movies.AddAsync(movieToAdd);
            await context.SaveChangesAsync();
            foreach (var genreId in movie.GenreIds!)
            {
                var movieGenre = new MovieGenre()
                {
                    GenreId = genreId,
                    MovieId = addedMovie.Entity.Id,
                };
                await context.MovieGenres.AddAsync(movieGenre);
            }
            foreach (var tagId in movie.TagIds!)
            {
                var movieTag = new MovieTag()
                {
                    TagId = tagId,
                    MovieId = addedMovie.Entity.Id,
                };
                await context.MovieTags.AddAsync(movieTag);

            }
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: MoviesController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var movieToEdit = context.Movies
                .Include(x => x.MovieGenres)
                .Include(x => x.MovieTags)
                .First(x => x.Id == id);
            var crudMovie = new CrudMovie()
            {
                OwnerId = movieToEdit.OwnerId,
                Title = movieToEdit.Title,
                ReleaseYear = movieToEdit.ReleaseYear,
                Director = movieToEdit.Director,
                Rating = movieToEdit.Rating,
                WatchedDate = movieToEdit.WatchedDate,
                Notes = movieToEdit.Notes,
                GenreIds = movieToEdit.MovieGenres!.Select(x => x.GenreId),
                TagIds = movieToEdit.MovieTags!.Select(x => x.TagId)
            };

            ViewBag.Genres = await context.Genres.ToListAsync();
            ViewBag.Tags = await context.Tags.ToListAsync();
            return View(crudMovie);
        }

        // POST: MoviesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CrudMovie crudMovie)
        {
            var movieToEdit = context.Movies
                .Include(x => x.MovieGenres)
                .Include(x => x.MovieTags)
                .First(x => x.Id == id);

            movieToEdit.Title = crudMovie.Title;
            movieToEdit.ReleaseYear = crudMovie.ReleaseYear;
            movieToEdit.Director = crudMovie.Director;
            movieToEdit.Rating = crudMovie.Rating;
            movieToEdit.WatchedDate = crudMovie.WatchedDate;
            movieToEdit.Notes = crudMovie.Notes;

            var movieToEditGenreIds = movieToEdit.MovieGenres!.Select(x => x.GenreId);
            var genresToRemove = movieToEditGenreIds.Except(crudMovie.GenreIds ?? new List<int>());
            if(genresToRemove != null)
            {
                foreach (var genreToRemove in genresToRemove)
                {
                    context.MovieGenres.Remove(movieToEdit.MovieGenres!.First(x => x.GenreId == genreToRemove));
                }
            }
            var movieToEditTagIds = movieToEdit.MovieTags!.Select(x => x.TagId);
            var tagsToRemove = movieToEditTagIds.Except(crudMovie.TagIds ?? new List<int>());
            if(tagsToRemove != null)
            {
                foreach (var tagToRemove in tagsToRemove)
                {
                    context.MovieTags.Remove(movieToEdit.MovieTags!.First(x => x.TagId == tagToRemove));
                }
            }
            var genresToAdd = crudMovie.GenreIds!.Except(movieToEditGenreIds ?? new List<int>());
            if(genresToAdd != null)
            {
                foreach (var genreToAdd in genresToAdd)
                {
                    context.MovieGenres.Add(new MovieGenre() { MovieId = movieToEdit.Id, GenreId = genreToAdd });
                }
            }
            var tagsToAdd = crudMovie.TagIds!.Except(movieToEditTagIds ?? new List<int>());
            if(tagsToAdd != null)
            {
                foreach (var tagToAdd in tagsToAdd)
                {
                    context.MovieTags.Add(new MovieTag() { MovieId = movieToEdit.Id, TagId = tagToAdd });
                }
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: MoviesController/Delete/5
        public ActionResult Delete(int id)
        {
            var movieToDelete = context.Movies
                .Include(x => x.MovieGenres)
                .Include(x => x.MovieTags)
                .First(x => x.Id == id);
            return View(movieToDelete);
        }

        // POST: MoviesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            var movieToDelete = context.Movies
                .Include(x => x.MovieGenres)
                .Include(x => x.MovieTags)
                .First(x => x.Id == id);

            context.Movies.Remove(movieToDelete);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
