using System.Collections.Generic;
using OrchardCore.Security.Permissions;

namespace Robots.OrchardCore {
    public class Permissions : IPermissionProvider {
        public static readonly Permission ManageRobots = new Permission("ManageRobots", "Manage Robots.txt");

        public IEnumerable<Permission> GetPermissions() {
            return new[] {ManageRobots};
        }

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes() {
            return new[] {
                new PermissionStereotype {
                    Name = "Administrator",
                    Permissions = new[] {ManageRobots}
                }
            };
        }
    }
}