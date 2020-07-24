using System.Threading.Tasks;
using Robots.OrchardCore.Models;
using Newtonsoft.Json.Linq;
using OrchardCore.Deployment;
using OrchardCore.Entities;
using OrchardCore.Settings;

namespace Robots.OrchardCore.Deployment {
    public class RobotsDeploymentSource : IDeploymentSource {
        private readonly ISiteService _siteService;

        public RobotsDeploymentSource(ISiteService siteService) {
            _siteService = siteService;
        }

        public async Task ProcessDeploymentStepAsync(DeploymentStep step, DeploymentPlanResult result) {
            var robotsState = step as RobotsDeploymentStep;

            if (robotsState == null) {
                return;
            }

            var siteSettings = await _siteService.GetSiteSettingsAsync();

            result.Steps.Add(new JObject(
                new JProperty("name", "Settings"),
                new JProperty("RobotsSettings", JObject.FromObject(siteSettings.As<RobotsSettings>()))
            ));
        }
    }
}