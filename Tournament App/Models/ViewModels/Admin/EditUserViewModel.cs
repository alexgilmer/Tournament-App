namespace Tournament_App.Models.ViewModels.Admin
{
    public class EditUserViewModel
    {
        public IList<Team> TeamList { get; init; }
        public Team? CurrentTeam { get; init; }
        public string ApplicationUserId { get; init; }
        public string Username { get; init; }
    }
}
