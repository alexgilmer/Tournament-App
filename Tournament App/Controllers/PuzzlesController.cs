using Microsoft.AspNetCore.Mvc;

namespace Tournament_App.Controllers
{
    public class PuzzlesController : Controller
    {
        public const string FirstIpChallengeRoute = "/first";

        public IActionResult Index()
        {
            return View();
        }

        [Route(FirstIpChallengeRoute)]
        public IActionResult FirstIpChallenge()
        {
            return View();
        }
    }
}
