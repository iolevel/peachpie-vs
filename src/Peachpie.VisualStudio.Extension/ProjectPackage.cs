using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.ProjectSystem.VS;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.Win32;
using Task = System.Threading.Tasks.Task;

[assembly: ProjectTypeRegistration(Peachpie.VisualStudio.Extension.ProjectPackage.DummyProjectGuidString,
    "PHP (PeachPie)", "Common Project System (*.msbuildproj);*.msbuildproj", "msbuildproj"
    , language: "PeachPie"
    , Capabilities = "Managed;PHP;PeachPie;AppDesigner;OpenProjectFile;GenerateDocumentationFile"
    , LanguageVsTemplate = "PeachPie"
    , DisplayProjectTypeVsTemplate = "PHP (PeachPie)"
    //, PossibleProjectExtensions = "msbuildproj;phpproj;peachpieproj"
    )]

namespace Peachpie.VisualStudio.Extension
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration("#110", "#112", "0.9.38", IconResourceID = 400)]
    [Guid(ProjectPackage.PackageGuidString)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    public sealed class ProjectPackage : AsyncPackage
    {
        /// <summary>
        /// ProjectPackage GUID string.
        /// </summary>
        public const string PackageGuidString = "f9b17eaf-7e54-458e-9a84-cc3f151a459d";

        public const string DummyProjectGuidString = "fab17eaf-7e54-458e-9a84-cc3f151a459e";

        public const string CpsProjectGuidString = "13B669BE-BB05-4DDF-9536-439F39A36129";

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectPackage"/> class.
        /// </summary>
        public ProjectPackage()
        {
            // Inside this method you can place any initialization code that does not require
            // any Visual Studio service because at this point the package object is created but
            // not sited yet inside Visual Studio environment. The place to do all the other
            // initialization is the Initialize method.
        }

        #region Package Members

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initialization code that rely on services provided by VisualStudio.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token to monitor for initialization cancellation, which can occur when VS is shutting down.</param>
        /// <param name="progress">A provider for progress updates.</param>
        /// <returns>A task representing the async work of package initialization, or an already completed task if there is none. Do not return null from this method.</returns>
        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            // When initialized asynchronously, the current thread may be a background thread at this point.
            // Do any initialization that requires the UI thread after switching to the UI thread.
            await this.JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
        }

        #endregion
    }
}
