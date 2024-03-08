using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tournament_App.Data;
using Tournament_App.Models;
using Tournament_App.Models.ViewModels.Banners;

namespace Tournament_App.Controllers
{
    [Authorize(Roles = Constants.AdminRole)]
    public class BannersController : Controller
    {
        private readonly ApplicationDbContext Database;
        public BannersController(ApplicationDbContext context)
        {
            Database = context;
        }

        public IActionResult Index()
        {
            return View(Database.Banners.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateBannerFormModel vm)
        {
            Banner b = new()
            {
                FileName = vm.FileName,
                Link = vm.Link,
            };
            Database.Banners.Add(b);
            Database.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            Banner b = Database.Banners.Single(b => b.Id == id);
            Database.Banners.Remove(b);
            Database.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
