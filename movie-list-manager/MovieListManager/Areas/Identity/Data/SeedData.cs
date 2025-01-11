using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieListManager.Authorization;
using MovieListManager.Models;

namespace MovieListManager.Areas.Identity.Data
{
    public class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, string testUserPw)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // The admin user can do anything
                var adminId = await EnsureUser(serviceProvider, testUserPw, "Admin", "Adminowski", "admin@admin.com");
                await EnsureRole(serviceProvider, adminId, ConstantRoles.Administrator);

                // The normal user
                var userId = await EnsureUser(serviceProvider, testUserPw, "User", "Userowski", "user@user.com");

                SeedDB(context, adminId, userId);
            }
        }

        public static void SeedDB(ApplicationDbContext context, string adminId, string userId)
        {
            if (context.Movies.Any())
            {
                return;   // DB has been seeded
            }

            context.Movies.AddRange(
                new List<Movie>()
                {
                    new Movie
                    {
                        Title = "Little Buddha",
                        Description = "A group of Tibetan monks sets off on a journey to find the next reincarnation of their master Lama Dorje.",
                        Author = "Bernardo Bertolucci",
                        Rating = 5,
                        OwnerId = adminId
                    },
                    new Movie
                    {
                        Title = "The Matrix",
                        Description = "Computer hacker Neo learns from mysterious rebels that the world he lives in is only an image transmitted to his brain by robots.",
                        Author = "Lilly Wachowski",
                        Rating = 10,
                        OwnerId = userId
                    },
                });
            context.SaveChanges();
        }

        private static async Task<string> EnsureUser(IServiceProvider serviceProvider,
                                                    string testUserPw,string firstName, string lastName, string UserName)
        {
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                user = new ApplicationUser
                {
                    FirstName = firstName,
                    LastName = lastName,
                    UserName = UserName,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, testUserPw);
            }

            if (user == null)
            {
                throw new Exception("The password is probably not strong enough!");
            }

            return user.Id;
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider,
                                                                      string uid, string role)
        {
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (roleManager == null)
            {
                throw new Exception("roleManager null");
            }

            IdentityResult IR;
            if (!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new IdentityRole(role));
            }

            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            //if (userManager == null)
            //{
            //    throw new Exception("userManager is null");
            //}

            var user = await userManager.FindByIdAsync(uid);

            if (user == null)
            {
                throw new Exception("The testUserPw password was probably not strong enough!");
            }

            IR = await userManager.AddToRoleAsync(user, role);

            return IR;
        }
    }
}
