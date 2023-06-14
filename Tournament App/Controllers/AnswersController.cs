using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            ViewBag.AnswerList = new SelectList(Database.Answers, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateAnswerFormModel vm)
        {
            if (!vm.IsValid)
            {
                ViewBag.AnswerList = new SelectList(Database.Answers, "Id", "Name");
                return View();
            }

            Answer newAnswer = new()
            {
                Name = vm.Name,
                Code = vm.Code,
                Description = vm.Description,
                PointValue = vm.PointValue,
                Rarity = vm.Rarity,
                ImageFileName = vm.FileName,
                DescriptionVisible = vm.DescriptionVisible,
                ParentAnswerId = vm.ParentAnswer,
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
            Answer? answer = Database.Answers.Include(a => a.ParentAnswer).FirstOrDefault(a => a.Id == id);
            
            if (answer == null)
                return NotFound();

            ViewBag.AnswerList = new SelectList(Database.Answers, "Id", "Name");
            return View(answer);
        }

        [HttpPost]
        public IActionResult Edit(EditAnswerFormModel vm)
        {
            Answer? answer = Database.Answers.Include(a => a.ParentAnswer).FirstOrDefault(a => a.Id == vm.Id);

            if (answer == null)
                return NotFound();

            answer.Code = vm.Code;
            answer.Name = vm.Name;
            answer.Description = vm.Description;
            answer.PointValue = vm.PointValue;
            answer.DescriptionVisible = vm.DescriptionVisible;
            answer.ImageFileName = vm.FileName;
            answer.ParentAnswerId = vm.ParentAnswerId;
            answer.Rarity = vm.Rarity;

            Database.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ManageChildren(int id)
        {
            Answer? answer = Database.Answers
                .Include(a => a.ParentAnswer)
                .Include(a => a.ChildAnswers)
                .FirstOrDefault(a => a.Id == id);

            if (answer == null)
                return NotFound();

            IEnumerable<Answer> allAnswers = Database.Answers;
            IEnumerable<Answer> currentChildren = Database.Answers.Where(a => a.ParentAnswerId == id);

            var vm = new ManageChildrenViewModel(answer, allAnswers, currentChildren);

            return View(vm);
        }

        [HttpPost]
        public IActionResult ManageChildren(ICollection<int> children, int answerId)
        {
            Answer? answer = Database.Answers.Find(answerId);

            if (answer == null)
                return NotFound();

            foreach (Answer a in Database.Answers.Where(a => a.ParentAnswerId == answer.Id))
            {
                a.ParentAnswerId = null;
            }

            foreach (int id in children)
            {
                Answer? a = Database.Answers.Find(id);
                if (a != null)
                {
                    a.ParentAnswerId = answer.Id;
                }
            }

            Database.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
