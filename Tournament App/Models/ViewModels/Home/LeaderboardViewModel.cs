namespace Tournament_App.Models.ViewModels.Home
{
    public class LeaderboardViewModel
    {
        public bool ShowPointEntryForm => LoggedInUserTeamName != null;
        public string? LoggedInUserTeamName { get; set; }
        public Guid? LoggedInUserTeamId { get; set; }

        public LeaderboardUpdateModel LeaderboardUpdateModel { get; set; }
    }
}
