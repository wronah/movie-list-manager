using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieListManager.Areas.Identity.Data;
using MovieListManager.Authorization;
using MovieListManager.Models;

namespace MovieListManager.Areas.Identity.Pages.Movies
{
    //public class CreateModel : DI_BasePageModel
    //{
    //    public CreateModel(
    //        ApplicationDbContext context,
    //        IAuthorizationService authorizationService,
    //        UserManager<ApplicationUser> userManager)
    //        : base(context, authorizationService, userManager)
    //    {
    //    }

    //    public IActionResult OnGet()
    //    {
    //        return Page();
    //    }

    //    [BindProperty]
    //    public Movie Movie { get; set; }

    //    public async Task<IActionResult> OnPostAsync()
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return Page();
    //        }

    //        Movie.OwnerId = UserManager.GetUserId(User);

    //        var isAuthorized = await AuthorizationService.AuthorizeAsync(
    //                                                    User, Movie,
    //                                                    MovieOperations.Create);
    //        if (!isAuthorized.Succeeded)
    //        {
    //            return Forbid();
    //        }

    //        Context.Movies.Add(Movie);
    //        await Context.SaveChangesAsync();

    //        return RedirectToPage("./Index");
    //    }
    //}
}
