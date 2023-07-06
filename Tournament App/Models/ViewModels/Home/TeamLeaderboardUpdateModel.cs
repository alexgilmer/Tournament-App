using Microsoft.EntityFrameworkCore;
using Tournament_App.Data;

namespace Tournament_App.Models.ViewModels.Home
{
    public class TeamLeaderboardUpdateModel
    {
        public TeamAnswersListing TeamAnswerListing { get; init; }
        public IList<TeamListing> AllTeamPointsList { get; init; }

        public TeamLeaderboardUpdateModel(Guid userTeamId, ApplicationDbContext database)
        {
            HashSet<Team> allTeams = database.Teams.Include(t => t.TeamAnswers).ThenInclude(ta => ta.Answer).ToHashSet();
            Team userTeam = allTeams.First(t => t.Id == userTeamId);
            TeamAnswerListing = new TeamAnswersListing(userTeam, database);

            AllTeamPointsList = new List<TeamListing>();
            foreach (var team in allTeams)
            {
                TeamListing t = new()
                {
                    Name = team.Name,
                    Points = team.TeamAnswers.Sum(ta => ta.Answer.PointValue),
                    IsCurrentTeam = team.Id == userTeamId
                };

                AllTeamPointsList.Add(t);
            }

            AllTeamPointsList = AllTeamPointsList.OrderByDescending(t => t.Points).ToList();
        }

        public class TeamListing
        {
            public string Name { get; init; } = string.Empty;
            public int Points { get; init; }
            public bool IsCurrentTeam { get; init; }
            public string? StyleText
            {
                get
                {
                    if (IsCurrentTeam)
                    {
                        return "background-color: dodgerblue;color: white;";
                    }

                    return null;
                }
            }

            public string PointsText
            {
                get
                {
                    bool plural = Math.Abs(Points) != 1;

                    if (plural)
                        return $"{Points} points";

                    return $"{Points} point";
                }
            }
        }

        public class TeamAnswersListing
        {
            public IList<AnswerPartialViewModel> CapturedAnswers { get; init; }
            public IList<AnswerPartialViewModel> TargetAnswers { get; init; }

            public TeamAnswersListing(Team team, ApplicationDbContext database)
            {
                CapturedAnswers = team.TeamAnswers
                    .ToList()
                    .Select(ta => new AnswerPartialViewModel(
                        ta.Answer,
                        displayImage: true,
                        displayName: true,
                        displayDescriptionOverride: true
                        ))
                    .ToList();

                /**
                 * For an answer to show up as a "target" answer, it must:
                 * 1. Be currently uncaptured
                 * 2. Not be a red herring
                 * 3. Have (a parent that is captured) or (no parent)
                 */
                TargetAnswers = database.Answers
                    // Uncaptured
                    .Where(a => !database.TeamAnswers.Any(ta => ta.TeamId == team.Id && ta.AnswerId == a.Id))
                    
                    // Not a red herring
                    .Where(a => a.Rarity != AnswerRarity.RedHerring)

                    // Have a captured parent OR no parent
                    .Where(
                        a => database.TeamAnswers.Any(ta => ta.TeamId == team.Id && ta.AnswerId == a.ParentAnswerId)
                            || a.ParentAnswerId == null
                    )
                    .ToList()
                    .Select(a => new AnswerPartialViewModel(
                        a,
                        displayImage: true,
                        displayName: true
                        ))
                    .ToList();
            }
        }
    }
}
