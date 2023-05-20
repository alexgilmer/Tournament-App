using Microsoft.AspNetCore.Mvc;

namespace Tournament_App.Controllers
{
    public class PuzzlesController : Controller
    {
        // These are just commit hashes LOL
        public const string FirstIpChallengeRoute = "/001e84b4";
        public const string SecondIpChallengeRoute = "/4dcdfff2";
        public const string ThirdIpChallengeRoute = "/a398c3f0";
        public const string FourthIpChallengeRoute = "/80847201";

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
    }
}
