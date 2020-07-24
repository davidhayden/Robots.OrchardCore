using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Deployment;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.Modules;
using OrchardCore.Navigation;
using OrchardCore.Security.Permissions;
using OrchardCore.Settings;
using Robots.OrchardCore.Deployment;
using Robots.OrchardCore.Drivers;
using Robots.OrchardCore.Services;

namespace Robots.OrchardCore {
    public class Startup : StartupBase {
        public override void ConfigureServices(IServiceCollection services) {
            services.AddScoped<IDisplayDriver<ISite>, RobotsSiteSettingsDisplayDriver>();
            services.AddScoped<IPermissionProvider, Permissions>();
            services.AddScoped<INavigationProvider, AdminMenu>();

            services.AddTransient<IDeploymentSource, RobotsDeploymentSource>();
            services.AddSingleton<IDeploymentStepFactory>(new DeploymentStepFactory<RobotsDeploymentStep>());
            services.AddScoped<IDisplayDriver<DeploymentStep>, RobotsDeploymentStepDriver>();

            services.AddScoped<IRobotsService, RobotsService>();
        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes,
            IServiceProvider serviceProvider) {
            routes.MapAreaControllerRoute(
                "Home",
                "Robots.OrchardCore",
                "robots.txt",
                new {controller = "Home", action = "Index"}
            );
        }
    }
}