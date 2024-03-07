using Tournament_App.Data;
using Tournament_App.Models;

namespace Tournament_App.Services
{
    public interface IBanner
    {
        public int Count { get; }
        public IList<Banner> GetBanners();
    }

    public class FreeBanners : IBanner
    {
        public int Count => 3;
        public IList<Banner> GetBanners()
        {
            return new List<Banner>() {
                new() { FileName = "https://placekitten.com/700/175?image=2", Link = "https://www.google.ca" },
                new() { FileName = "https://placekitten.com/700/175?image=3", Link = "https://www.facebook.com" },
                new() { FileName = "https://placekitten.com/700/175?image=4", Link = "https://www.linkedin.com" },
                };
        }
    }

    public class BannerService : IBanner
    {
        private readonly IList<Banner> _banners;
        public int Count => _banners.Count;

        public BannerService(ApplicationDbContext context)
        {
            _banners = context.Banners.ToList();
        }

        public IList<Banner> GetBanners()
        {
            return _banners;
        }
    }
}
