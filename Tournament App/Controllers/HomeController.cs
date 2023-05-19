using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Tournament_App.Data;
using Tournament_App.Models;
using Tournament_App.Models.ViewModels.Home;

namespace Tournament_App.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext Database;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            Database = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Leaderboard()
        {
            var teams = Database.Teams.Include(t => t.TeamAnswers).ThenInclude(ta => ta.Answer).ToList();

            List<LeaderboardViewModel.Group> groups = new();
            foreach (var team in teams)
            {
                LeaderboardViewModel.Group group = new()
                {
                    Name = team.Name,
                    Points = team.TeamAnswers.Sum(ta => ta.Answer.PointValue),
                    Members = Database.Users
                    .Where(u => u.TeamId == team.Id)
                    .Select(u => new LeaderboardViewModel.Member
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
                    .Select(u => new LeaderboardViewModel.Member() { ApplicationUserId = u.Id, Name = u.UserName })
                    .ToList()
            });

            // Insert data into view model
            var vm = new LeaderboardViewModel() { Groups = groups };

            return View(vm);
        }
    }
}