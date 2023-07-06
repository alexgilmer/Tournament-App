using Tournament_App.Data;

namespace Tournament_App.Models.ViewModels.Home
{
    public class TeamLeaderboardViewModel
    {
        public Guid UserTeamId { get; init; }
        public string UserTeamName { get; init; }

        public TeamLeaderboardUpdateModel UpdateModel { get; init; }

        public TeamLeaderboardViewModel(Guid userTeamId, string userTeamName, ApplicationDbContext database)
        {
            UserTeamId = userTeamId;
            UserTeamName = userTeamName ?? throw new ArgumentNullException(nameof(userTeamName));

            UpdateModel = new TeamLeaderboardUpdateModel(userTeamId, database);
        }
    }
}
