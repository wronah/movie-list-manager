using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieListManager.Areas.Identity.Data;
using MovieListManager.Models;

namespace MovieListManager.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TagsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public TagsController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        // GET: TagsController
        public async Task<IActionResult> Index()
        {
            var tags = await context.Tags.ToListAsync();
            return View(tags);
        }

        // GET: TagsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TagsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TagsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tag tag)
        {
            await context.Tags.AddAsync(tag);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: TagsController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View(await context.Tags.FirstAsync(x => x.Id == id));
        }

        // POST: TagsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Tag tag)
        {
            var tagToEdit = await context.Tags.FirstAsync(x => x.Id == id);
            tagToEdit.Name = tag.Name;
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: TagsController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return View(await context.Tags.FirstAsync(x => x.Id == id));
        }

        // POST: TagsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            var tagToDelete = await context.Tags.FirstAsync(x => x.Id == id);
            context.Tags.Remove(tagToDelete);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
