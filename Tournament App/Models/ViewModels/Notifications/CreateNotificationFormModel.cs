namespace Tournament_App.Models.ViewModels.Notifications
{
    public class CreateNotificationFormModel
    {
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public string HeaderColor { get; set; } = "#FFFFFF";
        public string TextColor { get; set; } = "#000000";

    }
}
