using Microsoft.Extensions.Primitives;
using System.Security.Claims;
using Tournament_App.Data;

namespace Tournament_App.Models.ViewModels.Puzzles
{
    public class AnswerSubmissionResult
    {
        public bool ValidCode { get; }
        public string AnswerName { get; }
        public int PointsAwarded { get; }
        public string Message { get; }

        public AnswerSubmissionResult(
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
                ValidCode = false;
                AnswerName = string.Empty;
                PointsAwarded = 0;
                Message = "Team not found.";
                return;
            }
            
            if (answer == null)
            {
                ValidCode = false;
                AnswerName = string.Empty;
                PointsAwarded = 0;
                Message = "Code not valid.";
                return;
            }

            TeamAnswer? teamAnswer = database.TeamAnswers.FirstOrDefault(ta => ta.TeamId == userTeam.Id && ta.AnswerId == answer.Id);
            if (teamAnswer != null)
            {
                ValidCode = false;
                AnswerName = answer.Name;
                PointsAwarded = 0;
                Message = $"Team {userTeam.Name} tried to reuse a code! SHAAAAAAME!";
                return;
            }

            ValidCode = true;
            AnswerName = answer.Name;
            PointsAwarded = answer.PointValue;
            Message = answer.PointValue > 0
                ? $"Team {userTeam.Name} scores {answer.PointValue} point(s)!"
                : $"Team {userTeam.Name} caught a red herring!  {-answer.PointValue} point(s) lost!";

            var ta = new TeamAnswer
            {
                TeamId = userTeam.Id,
                AnswerId = answer.Id
            };
            database.TeamAnswers.Add(ta);
            database.SaveChanges();
        }
    }
}
