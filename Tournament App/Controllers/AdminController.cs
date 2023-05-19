using Microsoft.AspNetCore.Authorization;
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
        public AdminController(ApplicationDbContext context)
        {
            Database = context;
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

            if (vm.NewTeamId == 0)
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
        public IActionResult EditTeam(int teamId)
        {
            Team? team = Database.Teams.Find(teamId);

            if (team == null)
                return NotFound();

            var vm = new EditTeamViewModel
            {
                Team = team
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult EditTeam(EditTeamFormModel vm)
        {
            Team? team = Database.Teams.Find(vm.TeamId);

            if (team != null)
            {
                team.Name = vm.NewTeamName;
                Database.SaveChanges();
            }

            return RedirectToAction("Index", "Teams");
        }

        [HttpGet]
        public IActionResult CreateTeam()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTeam(CreateTeamFormModel vm)
        {
            if (vm.Name != null && vm.Name.Trim().Length > 0)
            {
                var newTeam = new Team
                {
                    Name = vm.Name
                };

                Database.Teams.Add(newTeam);
                Database.SaveChanges();
            }

            return RedirectToAction("Index", "Teams");
        }
    }
}
