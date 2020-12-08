using Microsoft.VisualStudio;
using Microsoft.VisualStudio.ProjectSystem;
using Microsoft.VisualStudio.ProjectSystem.Build;
using Microsoft.VisualStudio.ProjectSystem.Properties;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peachpie.VisualStudio.Extension.Extensions
{
    /// <summary>
    /// Helper methods for VS specific interfaces.
    /// </summary>
    static class VSShellExtensions
    {
        public static UnconfiguredProject GetUnconfiguredProject(this IVsProject project)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            var context = project as IVsBrowseObjectContext;
            if (context == null)
            {
                // VC implements this on their DTE.Project.Object
                IVsHierarchy hierarchy = project as IVsHierarchy;
                if (hierarchy != null)
                {
                    if (ErrorHandler.Succeeded(hierarchy.GetProperty((uint)VSConstants.VSITEMID.Root, (int)__VSHPROPID.VSHPROPID_ExtObject, out var extObject)))
                    {
                        var dteProject = extObject as EnvDTE.Project;
                        if (dteProject != null)
                        {
                            context = dteProject.Object as IVsBrowseObjectContext;
                        }
                    }
                }
            }

            return context?.UnconfiguredProject;
        }

        public static UnconfiguredProject GetUnconfiguredProject(this EnvDTE.Project project)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            var context = project as IVsBrowseObjectContext;
            if (context == null && project != null)
            {
                // VC implements this on their DTE.Project.Object
                context = project.Object as IVsBrowseObjectContext;
            }

            return context?.UnconfiguredProject;
        }


        /// <summary>
        /// Gets <see cref="IVsWindowFrame"/> containing given view. Can return <c>null</c> e.g. in case of peek window.
        /// </summary>
        public static IVsWindowFrame ToIVsWindowFrame(this IVsTextView vsTextView)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            if (vsTextView == null)
            {
                throw new ArgumentNullException(nameof(vsTextView));
            }

            // Must be called on UI thread
            if (vsTextView is IVsTextViewEx ex && ErrorHandler.Succeeded(ex.GetWindowFrame(out var obj)))
            {
                if (obj is IVsWindowFrame frame)
                {
                    return frame;
                }
            }

            // legacy way
            //// IServiceProvider:
            //var objWithSite = (Microsoft.VisualStudio.OLE.Interop.IObjectWithSite)vsTextView;
            //Debug.Assert(objWithSite != null);
            //var sp = (IServiceProvider)objWithSite;
            //Debug.Assert(sp != null);

            //// IVsWindowFrame:
            //return (IVsWindowFrame)sp.GetService(typeof(SVsWindowFrame));
            //throw new NotSupportedException();
            return null;
        }

    }
}
