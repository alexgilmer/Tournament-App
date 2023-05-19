using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tournament_App.Data;
using Tournament_App.Models;
using Tournament_App.Models.ViewModels.Answers;

namespace Tournament_App.Controllers
{
    [Authorize(Roles = Constants.AdminRole)]
    public class AnswersController : Controller
    {
        private ApplicationDbContext Database { get; }

        public AnswersController(ApplicationDbContext db)
        {
            Database = db;
        }

        public IActionResult Index()
        {
            var answers = Database.Answers.ToList();
            return View(answers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateAnswerFormModel vm)
        {
            Answer newAnswer = new()
            {
                Name = vm.Name,
                Code = vm.Code,
                Description = vm.Description,
                PointValue = vm.PointValue
            };
            Database.Answers.Add(newAnswer);
            Database.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
