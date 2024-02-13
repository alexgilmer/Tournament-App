namespace Tournament_App.Models.ViewModels.GameData
{
    public class TeamDownloadsViewModel
    {
        public IEnumerable<TeamGameData>? GameData { get; set; }
        public string? TeamName { get; set; }
    }
}
