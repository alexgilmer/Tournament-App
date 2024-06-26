﻿using Microsoft.AspNetCore.Mvc;
using CodeAnalysis;
namespace Tournament_App.Controllers
{
    public class CodeProblemsController : Controller
    {
        public const string ControllerBaseRoute = "/CodeProblems";
        public const string JumpGameRoute = ControllerBaseRoute + "/jump-game-64d6bd5ee4b01d100b0a3dd5e0da42a7";
        public const string BallCountingEasyRoute = ControllerBaseRoute + "/ball-counting-easy-d8b3cc9532eb76b4089c3287f4e1aba4";
        public const string BallCountingRoute = ControllerBaseRoute + "/ball-counting-bdb7de8471436ae5b336dd02e414e8b1";
        public const string NestingDepthRoute = ControllerBaseRoute + "/nesting-depth-04ec6c37b7c3f425c47ae5cec47ef96e";
        public const string AverageBasesRoute = ControllerBaseRoute + "/average-bases-56ad4f5199a51571f997a3a0e7ba6cda";
        public const string PhoneWordsRoute = ControllerBaseRoute + "/phone-words-829b2456e90a09d9471066bf755b12b7";
        public const string TextJustificationRoute = ControllerBaseRoute + "/text-justification-c2a0b48bc2ed87a926982d75d64bb960";
        public const string RestockingEasyRoute = ControllerBaseRoute + "/restocking-easy-7f2001ba2be0e5f3dc7eb74101a8d2d4";
        public const string RestockingRoute = ControllerBaseRoute + "/restocking-b3e447d68b22122b9796746c0b7241d0";
        public const string AppendSortRoute = ControllerBaseRoute + "/append-sort-ca70ccd19d98d463f281f7ce50d1c8d2";

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FAQ()
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

        [HttpGet]
        [Route(AverageBasesRoute)]
        public IActionResult AverageBases()
        {
            return View();
        }

        [HttpPost]
        [Route(AverageBasesRoute)]
        public PartialViewResult AverageBases(string code)
        {
            CodeAnalysisResult result = CodeAnalyzer.GetTestResult(CodeProblem.AverageBases, code);
            return PartialView("_CodeResponsePartial", result);
        }

        [HttpGet]
        [Route(PhoneWordsRoute)]
        public IActionResult PhoneWords()
        {
            return View();
        }

        [HttpPost]
        [Route(PhoneWordsRoute)]
        public PartialViewResult PhoneWords(string code)
        {
            CodeAnalysisResult result = CodeAnalyzer.GetTestResult(CodeProblem.PhoneWords, code);
            return PartialView("_CodeResponsePartial", result);
        }

        [HttpGet]
        [Route(TextJustificationRoute)]
        public IActionResult TextJustification()
        {
            return View();
        }

        [HttpPost]
        [Route(TextJustificationRoute)]
        public PartialViewResult TextJustification(string code)
        {
            CodeAnalysisResult result = CodeAnalyzer.GetTestResult(CodeProblem.TextJustification, code);
            return PartialView("_CodeResponsePartial", result);
        }

        [HttpGet]
        [Route(RestockingEasyRoute)]
        public IActionResult RestockingEasy()
        {
            return View();
        }

        [HttpPost]
        [Route(RestockingEasyRoute)]
        public PartialViewResult RestockingEasy(string code)
        {
            CodeAnalysisResult result = CodeAnalyzer.GetTestResult(CodeProblem.RestockingEasy, code);
            return PartialView("_CodeResponsePartial", result);
        }

        [HttpGet]
        [Route(RestockingRoute)]
        public IActionResult Restocking()
        {
            return View();
        }

        [HttpPost]
        [Route(RestockingRoute)]
        public PartialViewResult Restocking(string code)
        {
            CodeAnalysisResult result = CodeAnalyzer.GetTestResult(CodeProblem.Restocking, code);
            return PartialView("_CodeResponsePartial", result);
        }

        [HttpGet]
        [Route(AppendSortRoute)]
        public IActionResult AppendSort()
        {
            return View();
        }

        [HttpPost]
        [Route(AppendSortRoute)]
        public PartialViewResult AppendSort(string code)
        {
            CodeAnalysisResult result = CodeAnalyzer.GetTestResult(CodeProblem.AppendSort, code);
            return PartialView("_CodeResponsePartial", result);
        }
    }
}
