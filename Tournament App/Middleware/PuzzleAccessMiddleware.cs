using Tournament_App.Data;
using Tournament_App.Models;
using Tournament_App.Services;

namespace Tournament_App.Middleware
{
    public class PuzzleAccessMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IFeatureControl _featureService;

        public PuzzleAccessMiddleware(RequestDelegate next, IFeatureControl service)
        {
            _next = next;
            _featureService = service;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!_featureService.IsEnabled(Constants.ControlNamePuzzlePages))
            {
                context.Response.Redirect("/FeatureDisabled");
                return;
            }

            await _next(context);
        }
    }
}
