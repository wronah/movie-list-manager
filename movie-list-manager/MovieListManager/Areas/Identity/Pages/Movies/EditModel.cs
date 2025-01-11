using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieListManager.Areas.Identity.Data;
using MovieListManager.Authorization;
using MovieListManager.Models;

namespace MovieListManager.Areas.Identity.Pages.Movies
{
    //public class EditModel : DI_BasePageModel
    //{
    //    public EditModel(
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
    //        Movie? movie = await Context.Movies.FirstOrDefaultAsync(
    //                                                         m => m.Id == id);
    //        if (movie == null)
    //        {
    //            return NotFound();
    //        }

    //        Movie = movie;

    //        var isAuthorized = await AuthorizationService.AuthorizeAsync(
    //                                                  User, Movie,
    //                                                  MovieOperations.Update);
    //        if (!isAuthorized.Succeeded)
    //        {
    //            return Forbid();
    //        }

    //        return Page();
    //    }

    //    public async Task<IActionResult> OnPostAsync(int id)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return Page();
    //        }

    //        // Fetch Movie from DB to get OwnerID.
    //        var movie = await Context
    //            .Movies.AsNoTracking()
    //            .FirstOrDefaultAsync(m => m.Id == id);

    //        if (movie == null)
    //        {
    //            return NotFound();
    //        }

    //        var isAuthorized = await AuthorizationService.AuthorizeAsync(
    //                                                 User, movie,
    //                                                 MovieOperations.Update);
    //        if (!isAuthorized.Succeeded)
    //        {
    //            return Forbid();
    //        }

    //        Movie.OwnerId = movie.OwnerId;

    //        Context.Attach(Movie).State = EntityState.Modified;

    //        await Context.SaveChangesAsync();

    //        return RedirectToPage("./Index");
    //    }
    //}
}
