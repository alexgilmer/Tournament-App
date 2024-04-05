using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Text.RegularExpressions;
using Tournament_App.Data;
using Tournament_App.Models;
using Tournament_App.Models.ViewModels.Puzzles;
using Tournament_App.Services;

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

        public const string PersonFinderRoute = ControllerBaseRoute + "/person-finder-fce243427b2a4";
        public const string PersonFinderSolutionRoute = ControllerBaseRoute + "person-finder-solution-e007d63a3d0ecee84ea9683b2f92ec14a7e20c92";

        private readonly ApplicationDbContext Database;
        private readonly UserManager<ApplicationUser> UserManager;
        private readonly IFeatureControl FeatureControl;

        public PuzzlesController(
            ApplicationDbContext db,
            UserManager<ApplicationUser> um,
            IFeatureControl fc)
        {
            Database = db;
            UserManager = um;
            FeatureControl = fc;
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
            if (!FeatureControl.IsEnabled(Constants.FeatureFlagCapture))
            {
                return Json(
                    new FlagSubmissionResult()
                    {
                        ValidFlag = false,
                        AnswerName = string.Empty,
                        PointsAwarded = 0,
                        Message = "Flag capture is currently disabled"
                    }
                );
            }
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

        [HttpGet]
        [Route(ControllerBaseRoute + "/stickthelanding")]
        public IActionResult StickTheLanding()
        {
            return View();
        }

        [HttpGet]
        [Route(PersonFinderRoute)]
        public IActionResult PersonFinder()
        {
            return View();
        }

        [HttpPost]
        [Route(PersonFinderRoute)]
        public IActionResult PersonFinder(string? submission)
        {
            submission ??= "";
            bool answerIsCorrect = Regex.IsMatch(submission, "the bull (and|&) finch pub", RegexOptions.IgnoreCase);

            if (answerIsCorrect)
                return RedirectToAction("PersonFinderSolution");
            else
                return RedirectToAction("PersonFinder");
        }

        [HttpGet, Route(PersonFinderSolutionRoute)]
        public IActionResult PersonFinderSolution()
        {
            return View();
        }
    }
}
