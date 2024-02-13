using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Tournament_App.Data;
using Tournament_App.Models;
using Tournament_App.Models.ViewModels.GameData;

namespace Tournament_App.Controllers
{
    [Authorize(Roles = Constants.AdminRole)]
    public class GameDataController : Controller
    {
        private readonly ApplicationDbContext Database;
        private readonly UserManager<ApplicationUser> UserManager;
        private readonly SignInManager<ApplicationUser> SigninManager;

        public GameDataController(ApplicationDbContext dbContext, UserManager<ApplicationUser> um, SignInManager<ApplicationUser> sim)
        {
            Database = dbContext;
            UserManager = um;
            SigninManager = sim;
        }

        public IActionResult Index()
        {
            IEnumerable<GameData> data = Database.GameData
                .Include(gd => gd.TeamGameData)
                .ThenInclude(tgd => tgd.Team);

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.TeamList = Database.Teams.ToList();
            return View(null);
        }

        [HttpPost]
        public IActionResult Create(CreateGameDataFormModel vm)
        {
            // reading a text file
            if (vm.File != null)
            {
                using var sr = new StreamReader(vm.File.OpenReadStream());
                string text = sr.ReadToEnd();

                GameData newData = new()
                {
                    Data = text,
                    Description = vm.Description ?? string.Empty,
                    Name = vm.File.FileName
                };

                Database.GameData.Add(newData);

                foreach (Guid id in vm.TeamIds)
                {
                    Team t = Database.Teams.Single(team => team.Id == id);
                    TeamGameData newTGD = new()
                    {
                        Team = t,
                        GameData = newData
                    };
                    Database.TeamGameData.Add(newTGD);
                }

                Database.SaveChanges();
            }
            else
            {
                return RedirectToAction(nameof(Create));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Download(Guid id)
        {
            var gameData = Database.GameData.Single(gd => gd.Id == id);

            return FileDownload(gameData);
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var gameData = Database.GameData.Single(gd => gd.Id == id);

            Database.GameData.Remove(gameData);
            Database.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> TeamDownloads()
        {
            TeamDownloadsViewModel vm = new();

            if (SigninManager.IsSignedIn(User))
            {
                ApplicationUser? user = await UserManager.FindByNameAsync(User.Identity?.Name);
                Team? userTeam = Database.Teams.Find(user?.TeamId);
                if (userTeam != null)
                {
                    vm.TeamName = userTeam.Name;
                    vm.GameData = Database.TeamGameData.Include(tgd => tgd.GameData).Where(tgd => tgd.TeamId == userTeam.Id);
                }
            }

            return View(vm);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> DownloadData(Guid id)
        {
            if (SigninManager.IsSignedIn(User))
            {
                ApplicationUser? user = await UserManager.FindByNameAsync(User.Identity?.Name);
                Team? userTeam = Database.Teams.Find(user?.TeamId);
                GameData gameData = Database.GameData.Single(gd => gd.Id == id);
                if (userTeam != null &&
                    Database.TeamGameData.Any(tgd => tgd.GameDataId == gameData.Id && tgd.TeamId == userTeam.Id))
                {
                    return FileDownload(gameData);
                }
            }

            return RedirectToAction("Index", "Home");
        }

        private FileContentResult FileDownload(GameData gameData)
        {
            string data = gameData.Data;
            byte[] fileBytes = Encoding.UTF8.GetBytes(data);

            string contentType = "text/plain";
            string fileName = gameData.Name;

            return File(fileBytes, contentType, fileName);
        }
    }
}
