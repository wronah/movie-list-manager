using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieListManager.Areas.Identity.Data;
using MovieListManager.Authorization;
using MovieListManager.Models;

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
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MoviesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MoviesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MoviesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MoviesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MoviesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MoviesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
