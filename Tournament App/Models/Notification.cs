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
            Title = "Flag capture!";
            HeaderColor = Constants.GetRarityColor(answer.Rarity);
            Text = $"Team {userTeam.Name} has captured {answer.Name}";
        }
    }
}
