using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tournament_App.Data;
using Tournament_App.Models;
using Tournament_App.Models.ViewModels.Teams;

namespace Tournament_App.Controllers
{
    public class TeamsController : Controller
    {
        private ApplicationDbContext Database { get; }

        public TeamsController(ApplicationDbContext db)
        {
            Database = db;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var teams = Database.Teams.Include(t => t.TeamAnswers).ThenInclude(ta => ta.Answer).ToList();

            List<IndexViewModel.Group> groups = new();
            foreach (var team in teams)
            {
                IndexViewModel.Group group = new()
                {
                    Name = team.Name,
                    Points = team.TeamAnswers.Sum(ta => ta.Answer.PointValue),
                    Members = Database.Users
                    .Where(u => u.TeamId == team.Id)
                    .Select(u => new IndexViewModel.Member
                    {
                        ApplicationUserId = u.Id,
                        Name = u.UserName
                    }).ToList()
                };

                groups.Add(group);
            }

            groups.Add(new()
            {
                Name = "Unassigned",
                Points = 0,
                Members = Database.Users
                    .Where(u => u.TeamId == null)
                    .Select(u => new IndexViewModel.Member() { ApplicationUserId = u.Id, Name = u.UserName })
                    .ToList()
            });

            // Insert data into view model
            var vm = new IndexViewModel() { Groups = groups };

            return View(vm);
        }
    }
}
