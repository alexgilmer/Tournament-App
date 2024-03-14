using Microsoft.AspNetCore.Mvc;
using CodeAnalysis;
namespace Tournament_App.Controllers
{
    public class CodeProblemsController : Controller
    {
        public const string ControllerBaseRoute = "/CodeProblems";
        public const string JumpGameRoute = ControllerBaseRoute + "/64d6bd5ee4b01d100b0a3dd5e0da42a7";

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route(JumpGameRoute)]
        public IActionResult JumpGame()
        {
            return View();
        }

        [HttpPost]
        [Route(JumpGameRoute)]
        public PartialViewResult JumpGame(string code)
        {
            CodeAnalysisResult result = CodeAnalyzer.GetTestResult(CodeProblem.JumpGame, code);
            return PartialView("_CodeResponsePartial", result);
        }
    }
}
