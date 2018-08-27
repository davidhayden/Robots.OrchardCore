using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Entities.DisplayManagement;
using OrchardCore.Settings;
using Robots.OrchardCore.Models;
using Robots.OrchardCore.ViewModels;

namespace Robots.OrchardCore.Drivers {
    public class RobotsSiteSettingsDisplayDriver : SectionDisplayDriver<ISite, RobotsSettings> {
        public const string GroupId = "robots";
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthorizationService _authorizationService;

        public RobotsSiteSettingsDisplayDriver(
            IHttpContextAccessor httpContextAccessor,
            IAuthorizationService authorizationService) {
            _httpContextAccessor = httpContextAccessor;
            _authorizationService = authorizationService;
        }

        public override async Task<IDisplayResult> EditAsync(RobotsSettings settings, BuildEditorContext context) {
            var user = _httpContextAccessor.HttpContext?.User;

            if (!await _authorizationService.AuthorizeAsync(user, Permissions.ManageRobots)) {
                return null;
            }

            return Initialize<RobotsSettingsViewModel>("RobotsSettings_Edit", m => { m.Text = settings.Text; })
                .Location("Content:1").OnGroup(GroupId);
        }

        public override async Task<IDisplayResult> UpdateAsync(RobotsSettings settings, BuildEditorContext context) {
            var user = _httpContextAccessor.HttpContext?.User;

            if (!await _authorizationService.AuthorizeAsync(user, Permissions.ManageRobots)) {
                return null;
            }

            if (context.GroupId == GroupId) {
                var model = new RobotsSettingsViewModel();

                await context.Updater.TryUpdateModelAsync(model, Prefix);

                settings.Text = model.Text;
            }

            return await EditAsync(settings, context);
        }
    }
}