using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Tournament_App.Data;
using Tournament_App.Models;

namespace Tournament_App.Controllers
{
    public class PuzzlesController : Controller
    {
        // These are just commit hashes LOL
        public const string FirstIpChallengeRoute = "/001e84b4";
        public const string SecondIpChallengeRoute = "/4dcdfff2";
        public const string ThirdIpChallengeRoute = "/a398c3f0";
        public const string FourthIpChallengeRoute = "/80847201";

        private readonly ApplicationDbContext Database;

        public PuzzlesController(ApplicationDbContext db)
        {
            Database = db;
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

        [HttpPost]
        public JsonResult Submit(IFormCollection formData)
        {
            StringValues strings = formData["flag"];

            if (strings.Count == 1)
            {
                string? flag = strings[0];
                Answer? answer = Database.Answers.FirstOrDefault(a => a.Code == flag);
                if (answer != null)
                {
                    return Json(answer);
                }
            }

            return Json(new
            {
                something = "something else",
                success = "some value",
                error = "LOL"
            });
        }
    }
}
