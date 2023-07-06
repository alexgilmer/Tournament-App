using Microsoft.EntityFrameworkCore;
using Tournament_App.Data;

namespace Tournament_App.Models.ViewModels.Home
{
    public class NeutralLeaderboardUpdateModel
    {
        public IList<LeaderboardTeam> Teams { get; set; }

        public NeutralLeaderboardUpdateModel(IList<Team> teams)
        {
            Teams = new List<LeaderboardTeam>();

            foreach (Team team in teams)
            {
                Teams.Add(new LeaderboardTeam(team));
            }

            Teams = Teams.OrderByDescending(t => t.PointsScored).ToList();
        }

        public NeutralLeaderboardUpdateModel(ApplicationDbContext database) : this(
            database.Teams
                .Include(t => t.ApplicationUsers)
                .Include(t => t.TeamAnswers)
                .ThenInclude(ta => ta.Answer)
                .ToList()
            )
        { }

        public class LeaderboardTeam
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public int PointsScored { get; set; }
            public IList<AnswerPartialViewModel> Answers { get; set; }
            public IList<Member> Members { get; set; }
            public LeaderboardTeam(Team team)
            {
                Id = team.Id;
                Name = team.Name;
                PointsScored = team.TeamAnswers.Sum(ta => ta.Answer.PointValue);
                Members = new List<Member>();
                foreach (ApplicationUser user in team.ApplicationUsers)
                {
                    Members.Add(new Member(user));
                }
                Answers = new List<AnswerPartialViewModel>();
                foreach (TeamAnswer ta in team.TeamAnswers)
                {
                    Answers.Add(new AnswerPartialViewModel(
                        ta.Answer,
                        displayImage: true,
                        displayName: true,
                        displayDescriptionOverride: false));
                }
            }

            public class Member
            {
                public string Name { get; set; }
                public string ApplicationUserId { get; set; }

                public Member(ApplicationUser user)
                {
                    Name = user.UserName;
                    ApplicationUserId = user.Id;
                }
            }
        }
    }
}
