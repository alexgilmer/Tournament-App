using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tournament_App.Data;
using Tournament_App.Models;
using Tournament_App.Models.ViewModels.Admin;
using Tournament_App.Models.ViewModels.Notifications;

namespace Tournament_App.Controllers
{
    [Authorize(Roles = Constants.AdminRole)]
    public class NotificationsController : Controller
    {
        
        private ApplicationDbContext Database { get; }

        public NotificationsController(ApplicationDbContext db)
        {
            Database = db;
        }

        public IActionResult Index()
        {
            var teams = Database.Notifications.ToList();

            return View(teams);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateNotificationFormModel vm)
        {
            var newNote = new Notification()
            {
                Title = vm.Title ?? string.Empty,
                Text = vm.Text ?? string.Empty,
                HeaderColor = vm.HeaderColor ?? "#FFFFFF",
            };
            Database.Notifications.Add(newNote);
            Database.SaveChanges();

            return RedirectToAction("Index", "Notifications");
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            Notification? result = Database.Notifications.FirstOrDefault(n => n.Id == id);
            if (result == null)
            {
                return NotFound();
            }

            Database.Notifications.Remove(result);
            Database.SaveChanges();
            return RedirectToAction("Index", "Notifications");
        }
    }
}
