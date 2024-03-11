using Tournament_App.Controllers;
using Tournament_App.Models;

namespace Tournament_App.Services
{
    public interface IFlagBanner
    {
        public string ImagePath { get; }
        public string Link { get; }
    }

    public class FlagBanner : IFlagBanner
    {
        public string ImagePath => Constants.ImagePrefix + "Hackathon-Banner.jpeg";
        public string Link => PuzzlesController.PersonFinderRoute;
    }
}
