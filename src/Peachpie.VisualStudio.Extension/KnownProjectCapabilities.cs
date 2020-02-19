using Microsoft.VisualStudio.ProjectSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peachpie.VisualStudio.Extension
{
    static class KnownProjectCapabilities
    {
        public const string PeachPieCapability = "PeachPie";

        public const string AppDesignerCapability = "AppDesigner";

        public const string PackCapability = "Pack";

        public const string LaunchProfilesCapability = "LaunchProfiles";

        public static bool HasPack(this IProjectCapabilitiesScope capabilitiesScope) => capabilitiesScope.Contains(PackCapability);

        public static bool HasLaunchProfiles(this IProjectCapabilitiesScope capabilitiesScope) => capabilitiesScope.Contains(LaunchProfilesCapability);

        public static bool HasPeachPie(this IProjectCapabilitiesScope capabilitiesScope) => capabilitiesScope.Contains(PeachPieCapability);
    }
}
