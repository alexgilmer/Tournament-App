using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tournament_App.Data;
using Tournament_App.Models;
using Tournament_App.Models.ViewModels.Teams;

namespace Tournament_App.Controllers
{
    public class TeamsController : Controller
    {
        private ApplicationDbContext Database { get; }

        public TeamsController(ApplicationDbContext db)
        {
            Database = db;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            // AsEnumerable() forces the DB to resolve the results
            // prevents an error of translating LINQ to SQL
            var groups = Database.ApplicationUsers
                .Include(u => u.Team)
                .AsEnumerable()
                .GroupBy(u => u.Team)
                .Select(g => new IndexViewModel.Group
                {
                    Name = g.Key == null ? "Unassigned" : g.Key.Name,
                    Points = g.Key == null ? 0 : g.Key.TeamAnswers.Sum(ta => ta.Answer.PointValue),
                    Members = g.Select(m => new IndexViewModel.Member
                    {
                        Name = m.UserName,
                        ApplicationUserId = m.Id
                    }).ToList()
                })
                .OrderByDescending(g => g.Points)
                .ToList();

            // Insert data into view model
            var vm = new IndexViewModel() { Groups = groups };

            return View(vm);
        }
    }
}
