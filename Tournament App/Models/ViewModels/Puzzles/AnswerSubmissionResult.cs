using Microsoft.Extensions.Primitives;
using System.Security.Claims;
using Tournament_App.Data;

namespace Tournament_App.Models.ViewModels.Puzzles
{
    public class FlagSubmissionResult
    {
        public bool ValidFlag { get; init;  }
        public string AnswerName { get; init; }
        public int PointsAwarded { get; init; }
        public string Message { get; init; }

        public FlagSubmissionResult(
            ApplicationDbContext database,
            ApplicationUser user,
            IFormCollection formData)
        {
            StringValues strings = formData["flag"];
            string input = strings.Count == 1 ? (strings[0] ?? string.Empty) : string.Empty;
            Team? userTeam = database.Teams.Find(user.TeamId);
            
            // because SQL is case-insensitive
            Answer? answer = database.Answers.FirstOrDefault(a => a.Code == input);
            if (answer != null && answer.Code != input)
            {
                answer = null;
            }

            if (userTeam == null)
            {
                ValidFlag = false;
                AnswerName = string.Empty;
                PointsAwarded = 0;
                Message = "Error: team not found.";
                return;
            }
            
            if (answer == null)
            {
                ValidFlag = false;
                AnswerName = "Invalid flag";
                PointsAwarded = 0;
                Message = "No flag with that name in the database.";
                return;
            }

            TeamAnswer? teamAnswer = database.TeamAnswers.FirstOrDefault(ta => ta.TeamId == userTeam.Id && ta.AnswerId == answer.Id);
            if (teamAnswer != null)
            {
                ValidFlag = false;
                AnswerName = answer.Name;
                PointsAwarded = 0;
                Message = $"Team {userTeam.Name} tried to reuse a flag! SHAAAAAAME!";
                return;
            }

            ValidFlag = true;
            AnswerName = answer.Name;
            PointsAwarded = answer.PointValue;
            Message = answer.Description;

            var ta = new TeamAnswer
            {
                TeamId = userTeam.Id,
                AnswerId = answer.Id
            };
            database.TeamAnswers.Add(ta);

            var note = new Notification(userTeam, answer);
            database.Notifications.Add(note);

            database.SaveChanges();
        }

        public FlagSubmissionResult() { }
    }
}
