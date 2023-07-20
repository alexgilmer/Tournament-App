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
        public IActionResult Edit(string id)
        {
            Notification? n = Database.Notifications.FirstOrDefault(note => note.Id == Guid.Parse(id));

            if (n == null)
                return NotFound();

            var vm = new EditNotificationViewModel
            {
                //Notification = n
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(EditNotificationFormModel vm)
        {
            Notification? n = Database.Notifications.FirstOrDefault(note => note.Id == Guid.Parse(/*vm.Id*/"  "));

            if (n != null)
            {
                throw new NotImplementedException();
                Database.SaveChanges();
            }

            return RedirectToAction("Index", "Teams");
        }
        
    }
}
