using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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

        [HttpGet]
        public IActionResult CreateMany()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMany(string input, bool wipePreviousData)
        {
            if (wipePreviousData)
            {
                Database.Answers.ExecuteDelete();
            }

            Answer[]? parsedJson = JsonConvert.DeserializeObject<Answer[]>(input);

            if (parsedJson != null)
            {
                Database.Answers.AddRange(parsedJson);
                Database.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Answer? answer = Database.Answers.Find(id);

            if (answer == null)
                return NotFound();

            return View(answer);
        }

        [HttpPost]
        public IActionResult Edit(EditAnswerFormModel vm)
        {
            Answer? answer = Database.Answers.Find(vm.Id);

            if (answer == null)
                return NotFound();

            answer.Code = vm.Code;
            answer.Name = vm.Name;
            answer.Description = vm.Description;
            answer.PointValue = vm.PointValue;

            Database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
