using Microsoft.VisualStudio.ProjectSystem;
using Microsoft.VisualStudio.ProjectSystem.VS.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peachpie.VisualStudio.Extension.ProjectDesigner
{
    [Export(typeof(IVsProjectDesignerPageProvider))]
    [AppliesTo(KnownProjectCapabilities.PeachPieCapability + "&" + KnownProjectCapabilities.AppDesignerCapability)]
    class ProjectDesignerPageProvider : IVsProjectDesignerPageProvider
    {
        readonly UnconfiguredProject _project;

        IProjectCapabilitiesScope Capabilities => _project.Capabilities;

        [ImportingConstructor]
        internal ProjectDesignerPageProvider(UnconfiguredProject project)
        {
            _project = project;
        }

        public Task<IReadOnlyCollection<IPageMetadata>> GetPagesAsync()
        {
            var result = new List<IPageMetadata>(8);

            // result.Add(Application); // only works for CSharp
            // result.Add(Build); // has a lot of not-quite-yet-supported properties
            result.Add(BuildEvents);
            if (Capabilities.HasPack())
            {
                result.Add(Package);
            }
            if (Capabilities.HasLaunchProfiles())
            {
                result.Add(Debug);
            }
            result.Add(Signing);
            //instance.Add(CodeAnalysis);
            return Task.FromResult<IReadOnlyCollection<IPageMetadata>>(result);
        }

        // following property pages are taken from C# projects:

        // static readonly ProjectDesignerPageMetadata Application = new ProjectDesignerPageMetadata(new Guid("{5E9A8AC2-4F34-4521-858F-4C248BA31532}"), 0, hasConfigurationCondition: false);

        static readonly ProjectDesignerPageMetadata Build = new ProjectDesignerPageMetadata(new Guid("{A54AD834-9219-4aa6-B589-607AF21C3E26}"), 1, hasConfigurationCondition: true);

        static readonly ProjectDesignerPageMetadata BuildEvents = new ProjectDesignerPageMetadata(new Guid("{1E78F8DB-6C07-4d61-A18F-7514010ABD56}"), 2, hasConfigurationCondition: false);

        static readonly ProjectDesignerPageMetadata Package = new ProjectDesignerPageMetadata(new Guid("{21b78be8-3957-4caa-bf2f-e626107da58e}"), 3, hasConfigurationCondition: false);

        static readonly ProjectDesignerPageMetadata Debug = new ProjectDesignerPageMetadata(new Guid("{0273C280-1882-4ED0-9308-52914672E3AA}"), 4, hasConfigurationCondition: false);

        // static readonly ProjectDesignerPageMetadata ReferencePaths = new ProjectDesignerPageMetadata(new Guid("{031911C8-6148-4e25-B1B1-44BCA9A0C45C}"), 5, hasConfigurationCondition: false);

        static readonly ProjectDesignerPageMetadata Signing = new ProjectDesignerPageMetadata(new Guid("{F8D6553F-F752-4DBF-ACB6-F291B744A792}"), 6, hasConfigurationCondition: false);

        // static readonly ProjectDesignerPageMetadata CodeAnalysis = new ProjectDesignerPageMetadata(new Guid("{c02f393c-8a1e-480d-aa82-6a75d693559d}"), 7, hasConfigurationCondition: false);
    }

}
