using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Tournament_App.Data;
using Tournament_App.Models;
using Tournament_App.Models.ProcessingModels;
using Tournament_App.Models.ViewModels.Admin;
using Tournament_App.Models.ViewModels.Teams;

namespace Tournament_App.Controllers
{
    [Authorize(Roles = Constants.AdminRole)]
    public class TeamsController : Controller
    {
        private ApplicationDbContext Database { get; }
        private UserManager<ApplicationUser> UserManager { get; }
        public TeamsController(ApplicationDbContext db, UserManager<ApplicationUser> um)
        {
            Database = db;
            UserManager = um;
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
        public IActionResult Edit(Guid id)
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
                team.ApiAlias = vm.NewTeamApiAlias;
                Database.SaveChanges();
            }

            return RedirectToAction("Index", "Teams");
        }

        [HttpGet]
        public IActionResult AddFileToTeam(Guid id)
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
        public async Task<IActionResult> AddFileToTeam(TeamFileFormModel vm)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult CreateMany()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMany(string input, bool wipePreviousData)
        {
            if (wipePreviousData)
            {
                Database.Teams.RemoveRange(Database.Teams);
                Database.ApplicationUsers.RemoveRange(
                    Database.ApplicationUsers.Where(u => u.UserName != "alex.gilmer@mitt.ca")
                    );
                await Database.SaveChangesAsync();
            }

            TeamFromJson[]? parsedJson = JsonConvert.DeserializeObject<TeamFromJson[]>(input);

            if (parsedJson != null)
            {
                foreach (var teamJson in parsedJson)
                {
                    Team t = new()
                    {
                        Name = teamJson.teamName,
                        ApiAlias = teamJson.apiAlias
                    };

                    List<ApplicationUser> teamMembers = new();

                    foreach (var memberJson in teamJson.members)
                    {
                        ApplicationUser u = new()
                        {
                            UserName = memberJson.username
                        };
                        var result = await UserManager.CreateAsync(u, memberJson.password);
                        
                        if (result.Succeeded)
                        {
                            teamMembers.Add(u);
                        }
                        else
                        {
                            throw new Exception($"Failed to create user due to errors: [ {string.Join(", ", result.Errors.Select(e => e.Description))} ]");
                        }
                    }

                    t.ApplicationUsers = teamMembers;
                    Database.Teams.Add(t);
                }

                Database.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
