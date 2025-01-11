using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieListManager.Areas.Identity.Data;
using MovieListManager.Authorization;
using MovieListManager.Models;

namespace MovieListManager.Areas.Identity.Pages.Movies
{
    //public class DeleteModel : DI_BasePageModel
    //{
    //    public DeleteModel(
    //        ApplicationDbContext context,
    //        IAuthorizationService authorizationService,
    //        UserManager<ApplicationUser> userManager)
    //        : base(context, authorizationService, userManager)
    //    {
    //    }

    //    [BindProperty]
    //    public Movie Movie { get; set; }

    //    public async Task<IActionResult> OnGetAsync(int id)
    //    {
    //        Movie? _movie = await Context.Movies.FirstOrDefaultAsync(
    //                                             m => m.Id == id);

    //        if (_movie == null)
    //        {
    //            return NotFound();
    //        }
    //        Movie = _movie;

    //        var isAuthorized = await AuthorizationService.AuthorizeAsync(
    //                                                 User, Movie,
    //                                                 MovieOperations.Delete);
    //        if (!isAuthorized.Succeeded)
    //        {
    //            return Forbid();
    //        }

    //        return Page();
    //    }

    //    public async Task<IActionResult> OnPostAsync(int id)
    //    {
    //        var movie = await Context
    //            .Movies.AsNoTracking()
    //            .FirstOrDefaultAsync(m => m.Id == id);

    //        if (movie == null)
    //        {
    //            return NotFound();
    //        }

    //        var isAuthorized = await AuthorizationService.AuthorizeAsync(
    //                                                 User, movie,
    //                                                 MovieOperations.Delete);
    //        if (!isAuthorized.Succeeded)
    //        {
    //            return Forbid();
    //        }

    //        Context.Movies.Remove(movie);
    //        await Context.SaveChangesAsync();

    //        return RedirectToPage("./Index");
    //    }
    //}
}
