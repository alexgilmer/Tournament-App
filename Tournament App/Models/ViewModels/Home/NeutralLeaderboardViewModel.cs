using Microsoft.EntityFrameworkCore;
using Tournament_App.Data;

namespace Tournament_App.Models.ViewModels.Home
{
    public class NeutralLeaderboardViewModel
    {
        public NeutralLeaderboardUpdateModel UpdateModel { get; set; }

        public NeutralLeaderboardViewModel(ApplicationDbContext database)
        {
            var teams = database.Teams
                .Include(t => t.ApplicationUsers)
                .Include(t => t.TeamAnswers)
                .ThenInclude(ta => ta.Answer)
                .ToList();

            UpdateModel = new(teams);
        }
    }
}
