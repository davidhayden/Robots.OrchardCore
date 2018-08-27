using System.Threading.Tasks;
using OrchardCore.Entities;
using OrchardCore.Settings;
using Robots.OrchardCore.Models;

namespace Robots.OrchardCore.Services {
    public class RobotsService : IRobotsService {
        private readonly ISiteService _siteService;

        public RobotsService(ISiteService siteService) {
            _siteService = siteService;
        }

        public async Task<string> FetchTextAsync() {
            var siteSettings = await _siteService.GetSiteSettingsAsync();
            return siteSettings.As<RobotsSettings>().Text ?? "";
        }
    }
}