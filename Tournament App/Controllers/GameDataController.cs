using Microsoft.AspNetCore.Authorization;
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

        public GameDataController(ApplicationDbContext dbContext)
        {
            Database = dbContext;
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

            string data = gameData.Data;
            byte[] fileBytes = Encoding.UTF8.GetBytes(data);

            string contentType = "text/plain";
            string fileName = gameData.Name;

            return File(fileBytes, contentType, fileName);
        }
    }
}
