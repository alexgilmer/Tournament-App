namespace Tournament_App.Models
{
    public class Notification
    {
        public Guid Id { get; set; } = new();
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public string HeaderColor { get; set; } = "#FFFFFF";
        public string TextColor { get; set; } = "#000000";
        public DateTime Created { get; set; } = DateTime.Now;

        public Notification() { }
        public Notification(Team userTeam, Answer answer)
        {
            HeaderColor = Constants.GetRarityColor(answer.Rarity);
            TextColor = Constants.GetRarityTextColor(answer.Rarity);
            Title = "Flag capture!";

            Text = $"Team {userTeam.Name} has captured: {answer.Name}";
        }

        public static readonly Notification Default = new()
        {
            Title = "Title Text",
            Text = "Body Text",
        };
    }
}
