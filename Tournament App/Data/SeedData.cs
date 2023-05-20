using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tournament_App.Models;

namespace Tournament_App.Data
{
    public class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, string seedUserPassword)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // For sample purposes seed both with the same password.
                // Password is set with the following:
                // dotnet user-secrets set SeedUserPW <pw>
                // The admin user can do anything

                var adminID = await EnsureUser(serviceProvider, seedUserPassword, "alex.gilmer@mitt.ca");
                await EnsureRole(serviceProvider, adminID, Constants.AdminRole);

                SeedDB(context);
            }
        }

        private static async Task<string> EnsureUser(IServiceProvider serviceProvider,
                                            string testUserPw, string UserName)
        {
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                user = new ApplicationUser
                {
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

        private static void SeedDB(ApplicationDbContext database)
        {
            if (!database.Teams.Any())
            {
                var amb = new Team
                {
                    Name = "Apathetic Mead Badgers"
                };

                var tau = new Team
                {
                    Name = "Tactical Assault Unicorns"
                };

                var pis = new Team
                {
                    Name = "Potassium-Infused Sleepwear"
                };

                var rfs = new Team
                {
                    Name = "Royal Fossil Society"
                };

                database.Teams.AddRange(amb, tau, pis, rfs);
                database.SaveChanges();
            }

            if (!database.Answers.Any())
            {
                var answers = new List<Answer>
                {
                    new Answer
                    {
                        Name = "Competent Reader",
                        Description = "You read the starting instructions",
                        Code = "lslfi8sern",
                        PointValue = 1
                    },

                    new Answer
                    {
                        Name = "Spammer",
                        Description = "You didn't read the instructions properly",
                        Code = "k823bknciwe7w872",
                        PointValue = -2
                    },

                    new Answer
                    {
                        Name = "Fjord",
                        Description = "You found the hidden instruction text",
                        Code = "FNORD",
                        PointValue = 1
                    },

                    new Answer
                    {
                        Name = "A Magic Phone Number",
                        Description = "You dodged the Rickroll",
                        Code = "8675309",
                        PointValue = 1
                    }
                };

                database.Answers.AddRange(answers);
            }
        }
    }
}
