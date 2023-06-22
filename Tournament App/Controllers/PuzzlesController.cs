﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Tournament_App.Data;
using Tournament_App.Models;
using Tournament_App.Models.ViewModels.Puzzles;

namespace Tournament_App.Controllers
{
    public class PuzzlesController : Controller
    {
        public const string ControllerBaseRoute = "/puzzles";

        // These are just commit hashes LOL
        public const string FirstIpChallengeRoute = ControllerBaseRoute + "/001e84b4";
        public const string SecondIpChallengeRoute = ControllerBaseRoute + "/4dcdfff2";
        public const string ThirdIpChallengeRoute = ControllerBaseRoute + "/a398c3f0";
        public const string FourthIpChallengeRoute = ControllerBaseRoute + "/80847201";

        private readonly ApplicationDbContext Database;
        private readonly UserManager<ApplicationUser> UserManager;

        public PuzzlesController(
            ApplicationDbContext db,
            UserManager<ApplicationUser> um)
        {
            Database = db;
            UserManager = um;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route(FirstIpChallengeRoute)]
        public IActionResult IpChallenge1()
        {
            // answer: "067"
            return View();
        }

        [Route(SecondIpChallengeRoute)]
        public IActionResult IpChallenge2()
        {
            // answer: "183"
            return View();
        }

        [Route(ThirdIpChallengeRoute)]
        public IActionResult IpChallenge3()
        {
            // answer: "230"
            return View();
        }

        [Route(FourthIpChallengeRoute)]
        public IActionResult IpChallenge4()
        {
            // answer: "119"
            return View();
        }

        [HttpGet]
        public IActionResult Submit()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Submit(IFormCollection formData)
        {
            ApplicationUser user = await UserManager.FindByNameAsync(User.Identity?.Name);

            FlagSubmissionResult result = new(Database, user, formData);

            return Json(result);
        }

        [HttpGet]
        [Route(ControllerBaseRoute + "/thepalindome")]
        public IActionResult Palindome()
        {
            return View();
        }

        [HttpGet]
        [Route(ControllerBaseRoute + "/bracketClicker")]
        public IActionResult ClickerGame()
        {
            ClickerGameViewModel vm = new(Request.Query);

            return View(vm);
        }
    }
}
