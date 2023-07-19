namespace Tournament_App.Models.ViewModels.Home
{
    public class NotificationViewModel
    {
        public Notification Notification { get; set; }
        public string TimeString
        {
            get
            {
                DateTime now = DateTime.Now;
                TimeSpan timeSpan = now - Notification.Created;
                
                if (timeSpan.TotalDays >= 1)
                {
                    int days = (int)timeSpan.TotalDays;
                    return Duration(days, "day");
                }

                if (timeSpan.TotalHours >= 1)
                {
                    int hours = (int)timeSpan.TotalHours;
                    return Duration(hours, "hour");
                }

                if (timeSpan.TotalMinutes >= 1)
                {
                    int minutes = (int)timeSpan.TotalMinutes;
                    return Duration(minutes, "minute");
                }

                int seconds = (int)timeSpan.TotalSeconds;
                return Duration(seconds, "second");
            }
        }

        private static string Duration(int amount, string type)
        {
            // parentheses necessary for parsing within string-interpolation
            // otherwise the colon breaks the parsing logic
            return $"{amount} {type}{(amount > 1 ? 's' : "")} ago";
        }

        public NotificationViewModel(Notification n)
        {
            Notification = n;
        }
    }
}
