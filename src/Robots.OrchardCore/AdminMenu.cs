using System;
using Microsoft.Extensions.Localization;
using OrchardCore.Environment.Navigation;
using Robots.OrchardCore.Drivers;

namespace Robots.OrchardCore {
    public class AdminMenu : INavigationProvider {
        public AdminMenu(IStringLocalizer<AdminMenu> localizer) {
            T = localizer;
        }

        public IStringLocalizer T { get; set; }

        public void BuildNavigation(string name, NavigationBuilder builder) {
            if (!String.Equals(name, "admin", StringComparison.OrdinalIgnoreCase)) {
                return;
            }

            builder
                .Add(T["Configuration"], configuration => configuration
                    .Add(T["Settings"], settings => settings
                        .Add(T["Robots.txt"], T["Robots.txt"], robots => robots
                            .Action("Index", "Admin",
                                new {area = "OrchardCore.Settings", groupId = RobotsSiteSettingsDisplayDriver.GroupId})
                            .Permission(Permissions.ManageRobots)
                            .LocalNav()
                        )));
        }
    }
}