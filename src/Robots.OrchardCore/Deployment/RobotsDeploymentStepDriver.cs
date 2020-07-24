using OrchardCore.Deployment;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.DisplayManagement.Views;

namespace Robots.OrchardCore.Deployment {
    public class RobotsDeploymentStepDriver : DisplayDriver<DeploymentStep, RobotsDeploymentStep> {
        public override IDisplayResult Display(RobotsDeploymentStep step) {
            return
                Combine(
                    View("RobotsDeploymentStep_Summary", step).Location("Summary", "Content"),
                    View("RobotsDeploymentStep_Thumbnail", step).Location("Thumbnail", "Content")
                );
        }

        public override IDisplayResult Edit(RobotsDeploymentStep step) {
            return View("RobotsDeploymentStep_Edit", step).Location("Content");
        }
    }
}