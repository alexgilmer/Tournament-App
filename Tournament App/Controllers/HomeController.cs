using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> UserManager;
        private readonly SignInManager<ApplicationUser> SigninManager;

        public HomeController(
            ILogger<HomeController> logger,
            ApplicationDbContext db,
            UserManager<ApplicationUser> um,
            SignInManager<ApplicationUser> sm)
        {
            _logger = logger;
            Database = db;
            UserManager = um;
            SigninManager = sm;
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

        public async Task<IActionResult> Leaderboard()
        {
            if (SigninManager.IsSignedIn(User))
            {
                ApplicationUser? user = await UserManager.FindByNameAsync(User.Identity?.Name);
                Team? userTeam = Database.Teams.Find(user?.TeamId);
                if (userTeam != null)
                {
                    return TeamLeaderboard(userTeam.Id, userTeam.Name);
                }
            }

            return NeutralLeaderboard();
        }

        private IActionResult NeutralLeaderboard()
        {
            var vm = new NeutralLeaderboardViewModel(Database);

            return View("NeutralLeaderboard", vm);
        }

        private IActionResult TeamLeaderboard(Guid userTeamId, string userTeamName)
        {
            var vm = new TeamLeaderboardViewModel(userTeamId, userTeamName, Database);

            return View("TeamLeaderboard", vm);
        }

        public IActionResult Instructions()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult GetLeaderboardUpdate()
        {
            var teams = Database.Teams
                .Include(t => t.ApplicationUsers)
                .Include(t => t.TeamAnswers)
                .ThenInclude(ta => ta.Answer)
                .OrderByDescending(t => t.TeamAnswers.Sum(ta => ta.Answer.PointValue))
                .ToList();

            var model = new LeaderboardUpdateModel(teams);

            return PartialView("_LeaderboardPartial", model);
        }

        public async Task<PartialViewResult> GetTeamLeaderboardUpdate()
        {
            if (SigninManager.IsSignedIn(User))
            {
                ApplicationUser? user = await UserManager.FindByNameAsync(User.Identity?.Name);
                Team? userTeam = Database.Teams.Find(user?.TeamId);
                if (userTeam != null)
                {
                    var model = new TeamLeaderboardUpdateModel(userTeam.Id, Database);

                    return PartialView("_TeamLeaderboardPartial", model);
                }
            }

            throw new Exception("User is not logged in");
        }

        public PartialViewResult GetNeutralLeaderboardUpdate()
        {
            var model = new NeutralLeaderboardUpdateModel(Database);

            return PartialView("_NeutralLeaderboardPartial", model);
        }

        public IActionResult AnswerBank()
        {
            List<AnswerPartialViewModel> result = Database.Answers
                .ToList()
                .Select(a => new AnswerPartialViewModel(
                    a,
                    displayImage: true,
                    displayName: true)
                )
                .ToList();

            return View(result);
        }

        public PartialViewResult GetNotifications()
        {
            IEnumerable<Notification> notifications = Database.Notifications
                .OrderByDescending(n => n.Created)
                .Take(8)
                .ToList();

            IEnumerable<NotificationViewModel> model = notifications.Select(n => new NotificationViewModel(n));

            return PartialView("_NotificationListPartial", model);
        }
    }
}