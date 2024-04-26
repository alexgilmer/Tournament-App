using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tournament_App.Data;
using Tournament_App.Models;
using Tournament_App.Models.ViewModels.Admin;

namespace Tournament_App.Controllers
{
    [Authorize(Roles = Constants.AdminRole)]
    public class AdminController : Controller
    {
        private ApplicationDbContext Database { get; }
        private UserManager<ApplicationUser> UserManager { get; }

        public AdminController(ApplicationDbContext context, UserManager<ApplicationUser> um)
        {
            Database = context;
            UserManager = um;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditUser(string userId)
        {
            ApplicationUser? user = Database.ApplicationUsers
                .Include(a => a.Team)
                .FirstOrDefault(a => a.Id == userId);

            if (user == null)
                return NotFound();

            var vm = new EditUserViewModel
            {
                TeamList = Database.Teams.ToList(),
                CurrentTeam = user.Team,
                ApplicationUserId = user.Id,
                Username = user.UserName,
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult EditUser(EditUserFormModel vm)
        {
            ApplicationUser? user = Database.Users.Find(vm.ApplicationUserId);
            
            if (user == null)
                return NotFound();

            if (vm.NewTeamId == null)
            {
                user.TeamId = null;
            }
            else
            {
                user.TeamId = vm.NewTeamId;
            }

            Database.SaveChanges();
            
            return RedirectToAction("Index", "Teams");
        }

        [HttpGet]
        public IActionResult WipeTeams()
        {
            return View();
        }

        [HttpPost]
        public IActionResult WipeTeams(WipeDataFormModel vm)
        {
            if (vm.Confirmed)
            {
                Database.Users.Where(u => u.TeamId != null).Load();
                Database.Teams.ExecuteDelete();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult WipeScoreBoard()
        {
            return View();
        }

        [HttpPost]
        public IActionResult WipeScoreBoard(WipeDataFormModel vm)
        {
            if (vm.Confirmed)
            {
                Database.TeamAnswers.ExecuteDelete();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult WipeAnswers()
        {
            return View();
        }

        [HttpPost]
        public IActionResult WipeAnswers(WipeDataFormModel vm)
        {
            if (vm.Confirmed)
            {
                Database.Answers.ExecuteDelete();
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult WipePlayers()
        {
            return View();
        }

        [HttpPost]
        public IActionResult WipePlayers(WipeDataFormModel vm)
        {
            if (vm.Confirmed)
            {
                var players = Database.ApplicationUsers
                    .Where(u => u.UserName != "alex.gilmer@mitt.ca");

                players.ExecuteDelete();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult WipeNotifications()
        {
            return View();
        }

        [HttpPost]
        public IActionResult WipeNotifications(WipeDataFormModel vm)
        {
            if (vm.Confirmed)
            {
                Database.Notifications.ExecuteDelete();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateAdmin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdmin(string username, string password)
        {
            ApplicationUser newUser = new()
            {
                UserName = username
            };

            var result = await UserManager.CreateAsync(newUser, password);

            if (!result.Succeeded)
            {
                return View();
            }

            result = await UserManager.AddToRoleAsync(newUser, Constants.AdminRole);

            if (!result.Succeeded)
            {
                return View();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
