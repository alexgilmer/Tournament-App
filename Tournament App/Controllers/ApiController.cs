using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tournament_App.Data;
using Tournament_App.Models;

namespace Tournament_App.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("/api/[action]")]
    public class ApiController : ControllerBase
    {
        private readonly ApplicationDbContext Database;

        public ApiController(ApplicationDbContext db)
        {
            Database = db;
        }

        [HttpPost]
        public IActionResult AddFlag([FromHeader] string? teamId, [FromHeader] string flagCode)
        {
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
