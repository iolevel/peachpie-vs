using EnvDTE;
using Microsoft.VisualStudio.Designer.Interfaces;
using Microsoft.VisualStudio.ProjectSystem;
using Microsoft.VisualStudio.ProjectSystem.VS;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peachpie.VisualStudio.Extension.CodeDom
{
    //[Export(typeof(ICodeModelProvider))]
    //[Export(typeof(IProjectCodeModelProvider))]
    //[AppliesTo(KnownProjectCapabilities.PeachPieCapability)]
    //internal class ProjectContextCodeModelProvider : ICodeModelProvider, IProjectCodeModelProvider
    //{
    //    public ProjectContextCodeModelProvider()
    //    {

    //    }

    //    public CodeModel GetCodeModel(Project project)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public FileCodeModel GetFileCodeModel(ProjectItem fileItem)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    [ExportVsProfferedProjectService(typeof(IVSMDCodeDomProvider))]
    [AppliesTo(KnownProjectCapabilities.PeachPieCapability)]
    class VSMDCodeDomProvider : IVSMDCodeDomProvider
    {
        public VSMDCodeDomProvider()
        {

        }

        public dynamic CodeDomProvider => throw new NotImplementedException();
    }

    [Export(typeof(CodeDomProvider))]
    [ExportVsProfferedProjectService(typeof(CodeDomProvider))]
    [AppliesTo(KnownProjectCapabilities.PeachPieCapability)]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    class PeachpieCodeDomProvider : CodeDomProvider
    {
        public PeachpieCodeDomProvider()
        {

        }

        public override void GenerateCodeFromCompileUnit(CodeCompileUnit compileUnit, TextWriter writer, CodeGeneratorOptions options)
        {
            base.GenerateCodeFromCompileUnit(compileUnit, writer, options);
        }

        public override CodeCompileUnit Parse(TextReader codeStream)
        {
            throw new NotImplementedException();
        }

        public override LanguageOptions LanguageOptions => LanguageOptions.CaseInsensitive;

        [Obsolete]
        public override ICodeCompiler CreateCompiler()
        {
            throw new NotImplementedException();
        }

        [Obsolete]
        public override ICodeGenerator CreateGenerator()
        {
            throw new NotImplementedException();
        }
    }
}
