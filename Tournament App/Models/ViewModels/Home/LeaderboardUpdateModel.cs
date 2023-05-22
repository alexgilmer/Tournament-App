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
            public int Id { get; set; }
            public string Name { get; set; }
            public int PointsScored { get; set; }
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
