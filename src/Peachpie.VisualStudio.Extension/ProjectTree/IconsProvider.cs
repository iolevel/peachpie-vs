using Microsoft.VisualStudio.ProjectSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peachpie.VisualStudio.Extension.ProjectTree
{
    [Export(typeof(IProjectTreePropertiesProvider))]
    [Order(1000)]
    [AppliesTo(KnownProjectCapabilities.PeachPieCapability)]
    class IconsProvider : IProjectTreePropertiesProvider
    {
        readonly static Dictionary<string, ProjectImageMoniker> s_iconsByExtension = new Dictionary<string, ProjectImageMoniker>(StringComparer.OrdinalIgnoreCase)
        {
            //{ ".php", ScriptFileNode },
        };

        /// <summary>
        /// Calculates new property values for each node in the project tree.
        /// </summary>
        /// <param name="propertyContext">Context information that can be used for the calculation.</param>
        /// <param name="propertyValues">Values calculated so far for the current node by lower priority tree properties providers.</param>
        public void CalculatePropertyValues(
            IProjectTreeCustomizablePropertyContext propertyContext,
            IProjectTreeCustomizablePropertyValues propertyValues)
        {
            if (propertyValues.Flags.Contains(ProjectTreeFlags.Common.FileOnDisk))
            {
                // icons for file items:
                var ext = Path.GetExtension(propertyContext.ItemName);
                if (ext != null && s_iconsByExtension.TryGetValue(ext, out var moniker))
                {
                    propertyValues.Icon = moniker;
                }
            }
            else if (propertyValues.Flags.Contains(ProjectTreeFlags.Common.ProjectRoot))
            {
                // project node icon:
                propertyValues.Icon = ImageCatalog.ProjectIcon.ToProjectSystemType();
            }
        }
    }
}
