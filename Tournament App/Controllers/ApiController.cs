using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tournament_App.Data;
using Tournament_App.Models;
using Tournament_App.Services;

namespace Tournament_App.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("/api/[action]")]
    public class ApiController : ControllerBase
    {
        private readonly ApplicationDbContext Database;
        private readonly IFeatureControl FeatureControl;

        public ApiController(ApplicationDbContext db, IFeatureControl fc)
        {
            Database = db;
            FeatureControl = fc;
        }

        [HttpPost]
        public IActionResult AddFlag([FromHeader] string? teamId, [FromHeader] string flagCode)
        {
            if (!FeatureControl.IsEnabled(Constants.FeatureFlagCapture))
            {
                return Forbid();
            }

            if (teamId == null)
            {
                return NotFound("teamId not found");
            }

            Team? team = Database.Teams.FirstOrDefault(t => t.ApiAlias == teamId);

            if (team == null)
            {
                return NotFound("Team not found");
            }

            Answer? answer = Database.Answers.FirstOrDefault(a => a.Code == flagCode);

            if (answer == null)
            {
                return NotFound("Answer not found");
            }

            if (Database.TeamAnswers.Any(ta => ta.TeamId == team.Id && ta.AnswerId == answer.Id))
            {
                return Ok("Team already has that flag.");
            }

            var ta = new TeamAnswer
            {
                TeamId = team.Id,
                AnswerId = answer.Id
            };
            Database.TeamAnswers.Add(ta);

            var note = new Notification(team, answer);

            Database.Notifications.Add(note);

            Database.SaveChanges();

            return Ok();
        }
    }
}
