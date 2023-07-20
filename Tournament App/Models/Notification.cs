namespace Tournament_App.Models
{
    public class Notification
    {
        public Guid Id { get; set; } = new();
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public string HeaderColor { get; set; } = "#FFFFFF";
        public DateTime Created { get; set; } = DateTime.Now;

        public Notification() { }
        public Notification(Team userTeam, Answer answer)
        {
            HeaderColor = Constants.GetRarityColor(answer.Rarity);
            Title = "Flag capture!";

            Text = $"Team {userTeam.Name} has captured a flag: \"{answer.Name}\"";
        }

        public static readonly Notification Default = new()
        {
            Title = "Title Text",
            Text = "Body Text",
        };
    }
}
