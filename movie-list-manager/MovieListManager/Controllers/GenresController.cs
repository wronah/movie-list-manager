using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieListManager.Areas.Identity.Data;
using MovieListManager.Models;

namespace MovieListManager.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GenresController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public GenresController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        // GET: GenresController
        public async Task<IActionResult> Index()
        {
            var genres = await context.Genres.ToListAsync();  
            return View(genres);
        }

        // GET: GenresController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GenresController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Genre genre)
        {
            await context.Genres.AddAsync(genre);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: GenresController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View(await context.Genres.FirstAsync(x => x.Id == id));
        }

        // POST: GenresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Genre genre)
        {
            var genreToEdit = await context.Genres.FirstAsync(x => x.Id == id);
            genreToEdit.Name = genre.Name;
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: GenresController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return View(await context.Genres.FirstAsync(x => x.Id == id));
        }

        // POST: GenresController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            var genreToDelete = await context.Genres.FirstAsync(x => x.Id == id);
            context.Genres.Remove(genreToDelete);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
