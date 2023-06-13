namespace Tournament_App.Models.ViewModels.Home
{
    public class LeaderboardUpdateModel
    {
        public IList<LeaderboardTeam> Teams { get; set; }

        public LeaderboardUpdateModel(IList<Team> teams)
        {
            Teams = new List<LeaderboardTeam>();

            foreach (Team team in teams)
            {
                Teams.Add(new LeaderboardTeam(team));
            }
        }

        public class LeaderboardTeam
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public int PointsScored { get; set; }
            public IList<LeaderboardTeamAnswer> Answers { get; set; }
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
                Answers = new List<LeaderboardTeamAnswer>();
                foreach (TeamAnswer ta in team.TeamAnswers)
                {
                    Answers.Add(new LeaderboardTeamAnswer()
                    {
                        Name = ta.Answer.Name,
                        Description = ta.Answer.Description,
                        PointValue = ta.Answer.PointValue
                    });
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

            public class LeaderboardTeamAnswer
            {
                public string Name { get; set; }
                public string Description { get; set; }
                public int PointValue { get; set; }
            }
        }
    }
}
