namespace Tournament_App.Models.ViewModels.Banners
{
    public class BannerPartialViewModel
    {
        private const string Prefix = Constants.BannerImagePrefix;
        private Banner _Banner { get; }

        public bool HasLink
        {
            get
            {
                return _Banner.Link != null && _Banner.Link.Length > 0;
            }
        }
        public string Link
        {
            get
            {
                return $"{_Banner.Link}";
            }
        }

        public string ImagePath
        {
            get
            {
                if (_Banner.FileName.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                    return _Banner.FileName;

                return Prefix + _Banner.FileName;
            }
        }

        public BannerPartialViewModel(Banner b)
        {
            _Banner = b;
        }
    }
}
