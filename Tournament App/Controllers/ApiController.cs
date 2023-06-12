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
        public IActionResult AddFlag([FromHeader] int teamId, [FromHeader] string flagCode)
        {
            Team? team = Database.Teams.Find(teamId);

            if (team == null)
            {
                return NotFound("Team not found");
            }

            Answer? answer = Database.Answers.FirstOrDefault(a => a.Code == flagCode);

            if (answer == null)
            {
                return NotFound("Answer not found");
            }

            if (answer.PointValue < 0)
            {
                return BadRequest("Stop trying to hurt the other teams, LOL!");
            }

            return Ok();
        }
    }
}
