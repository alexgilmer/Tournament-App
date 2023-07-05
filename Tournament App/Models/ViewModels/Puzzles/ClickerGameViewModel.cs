using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Tournament_App.Models.ViewModels.Puzzles
{
    public class ClickerGameViewModel
    {
        public int MaxClicksPerInterval { get; set; }
        public string? Message { get; set; }

        public ClickerGameViewModel(string? message = null, int clicks = 3)
        {
            Message = message;
            MaxClicksPerInterval = clicks;
        }

        public ClickerGameViewModel(IQueryCollection query)
        {
            MaxClicksPerInterval = 3;

            if (query.Count == 0)
            {
                Message = "You should find a way to QUERY the right information about this game...";
            }
            else
            {
                Message = "You should try seeking out how to modify the CLICKS";
            }

            foreach (var kvp in query)
            {
                if (kvp.Key.Contains("clicks", StringComparison.OrdinalIgnoreCase))
                {
                    Message = "Take a closer look at dataset attribute, you're getting there!";
                }

                if (kvp.Key.ToLower() == "maxclicksperinterval")
                {
                    Message = "You're SO close!  What would it look like if you tried to read it as a Javascript variable?";
                }

                if (kvp.Key == "maxClicksPerInterval")
                {
                    _ = int.TryParse(kvp.Value.FirstOrDefault() ?? "3", out int num);

                    ApplyMaxClicks(num);

                    break;
                }
            }
        }

        private void ApplyMaxClicks(int num)
        {
            Message = null;
            MaxClicksPerInterval = num;

            if (num < 1)
            {
                Message = "Minimum must be at least one.  That, or the parser broke trying to read the data and it returned zero.  Try an integer value from 1 to 1000.";
                MaxClicksPerInterval = 1;
            }

            if (num > 1000)
            {
                Message = "Maximum cannot be higher than 1000 per interval";
                MaxClicksPerInterval = 1000;
            }
        }
    }
}
