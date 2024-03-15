using Microsoft.AspNetCore.Mvc;
using CodeAnalysis;
namespace Tournament_App.Controllers
{
    public class CodeProblemsController : Controller
    {
        public const string ControllerBaseRoute = "/CodeProblems";
        public const string JumpGameRoute = ControllerBaseRoute + "/64d6bd5ee4b01d100b0a3dd5e0da42a7";
        public const string BallCountingEasyRoute = ControllerBaseRoute + "/d8b3cc9532eb76b4089c3287f4e1aba4";
        public const string BallCountingRoute = ControllerBaseRoute + "/bdb7de8471436ae5b336dd02e414e8b1";
        public const string NestingDepthRoute = ControllerBaseRoute + "/04ec6c37b7c3f425c47ae5cec47ef96e";

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

        [HttpGet]
        [Route(BallCountingEasyRoute)]
        public IActionResult BallCountingEasy()
        {
            return View();
        }

        [HttpPost]
        [Route(BallCountingEasyRoute)]
        public PartialViewResult BallCountingEasy(string code)
        {
            CodeAnalysisResult result = CodeAnalyzer.GetTestResult(CodeProblem.BallCountingEasy, code);
            return PartialView("_CodeResponsePartial", result);
        }

        [HttpGet]
        [Route(BallCountingRoute)]
        public IActionResult BallCounting()
        {
            return View();
        }

        [HttpPost]
        [Route(BallCountingRoute)]
        public PartialViewResult BallCounting(string code)
        {
            CodeAnalysisResult result = CodeAnalyzer.GetTestResult(CodeProblem.BallCounting, code);
            return PartialView("_CodeResponsePartial", result);
        }

        [HttpGet]
        [Route(NestingDepthRoute)]
        public IActionResult NestingDepth()
        {
            return View();
        }

        [HttpPost]
        [Route(NestingDepthRoute)]
        public PartialViewResult NestingDepth(string code)
        {
            CodeAnalysisResult result = CodeAnalyzer.GetTestResult(CodeProblem.NestingDepth, code);
            return PartialView("_CodeResponsePartial", result);
        }
    }
}
