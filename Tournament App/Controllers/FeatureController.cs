using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tournament_App.Data;
using Tournament_App.Models;

namespace Tournament_App.Controllers
{
    [Authorize(Roles = Constants.AdminRole)]
    public class FeatureController : Controller
    {
        private readonly ApplicationDbContext Database;

        public FeatureController(ApplicationDbContext db)
        {
            Database = db;
        }

        public IActionResult Index()
        {
            return View(Database.FeatureControls);
        }

        public IActionResult Toggle(string name)
        {
            FeatureControl fc = Database.FeatureControls.Single(f => f.Name == name);
            fc.IsEnabled = !fc.IsEnabled;
            Database.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
