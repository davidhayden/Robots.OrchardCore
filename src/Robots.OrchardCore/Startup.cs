using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.Modules;
using OrchardCore.Navigation;
using OrchardCore.Security.Permissions;
using OrchardCore.Settings;
using Robots.OrchardCore.Drivers;
using Robots.OrchardCore.Services;

namespace Robots.OrchardCore {
    public class Startup : StartupBase {
        public override void ConfigureServices(IServiceCollection services) {
            services.AddScoped<IDisplayDriver<ISite>, RobotsSiteSettingsDisplayDriver>();
            services.AddScoped<IPermissionProvider, Permissions>();
            services.AddScoped<INavigationProvider, AdminMenu>();

            services.AddScoped<IRobotsService, RobotsService>();
        }

        public override void Configure(IApplicationBuilder builder, IRouteBuilder routes,
            IServiceProvider serviceProvider) {
            routes.MapAreaRoute(
                "Home",
                "Robots.OrchardCore",
                "robots.txt",
                new {controller = "Home", action = "Index"}
            );
        }
    }
}