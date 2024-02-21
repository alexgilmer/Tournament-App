using Tournament_App.Data;
using Tournament_App.Models;

namespace Tournament_App.Services
{
    public interface IFeatureControl
    {
        public bool IsEnabled(string featureName);
    }

    public class FreeFeatureControl : IFeatureControl
    {
        public bool IsEnabled(string _)
        {
            return true;
        }
    }

    public class FeatureControlLogic : IFeatureControl
    {
        private readonly ApplicationDbContext Database;
        public FeatureControlLogic(ApplicationDbContext context)
        {
            Database = context;
        }

        public bool IsEnabled(string featureName)
        {
            FeatureControl? fc = Database.FeatureControls.SingleOrDefault(f => f.Name == featureName);
            return fc == null || fc.IsEnabled;
        }
    }
}
