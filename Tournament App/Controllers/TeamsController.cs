using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tournament_App.Data;
using Tournament_App.Models;
using Tournament_App.Models.ViewModels.Admin;
using Tournament_App.Models.ViewModels.Teams;

namespace Tournament_App.Controllers
{
    [Authorize(Roles = Constants.AdminRole)]
    public class TeamsController : Controller
    {
        private ApplicationDbContext Database { get; }

        public TeamsController(ApplicationDbContext db)
        {
            Database = db;
        }

        public IActionResult Index()
        {
            var teams = Database.Teams.ToList();

            return View(teams);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateTeamFormModel vm)
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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Team? team = Database.Teams.Find(id);

            if (team == null)
                return NotFound();

            var vm = new EditTeamViewModel
            {
                Team = team
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(EditTeamFormModel vm)
        {
            Team? team = Database.Teams.Find(vm.TeamId);

            if (team != null)
            {
                team.Name = vm.NewTeamName;
                Database.SaveChanges();
            }

            return RedirectToAction("Index", "Teams");
        }

    }
}
