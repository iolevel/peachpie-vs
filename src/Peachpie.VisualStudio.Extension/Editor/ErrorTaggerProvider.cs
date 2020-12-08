using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peachpie.VisualStudio.Extension.Editor
{
    [Export(typeof(IViewTaggerProvider))]
    [ContentType("code++.PHP"), ContentType("PHP")]
    [Order(Before = "default")]
    [TagType(typeof(IErrorTag))]
    class ErrorTaggerProvider : IViewTaggerProvider
    {
        public ITagger<T> CreateTagger<T>(ITextView textView, ITextBuffer buffer) where T : ITag
        {
            var tagger = (ITagger<IErrorTag>)buffer.Properties.GetOrCreateSingletonProperty<ErrorTagger>(() => new ErrorTagger(buffer));

            return (ITagger<T>)tagger;
        }
    }

    sealed class ErrorTagger : ITagger<ErrorTag>, IDisposable
    {
        public ITextBuffer Buffer { get; }

        public ErrorTagger(ITextBuffer buffer)
        {
            Buffer = buffer;
        }

        public event EventHandler<SnapshotSpanEventArgs> TagsChanged;

        public IEnumerable<ITagSpan<ErrorTag>> GetTags(NormalizedSnapshotSpanCollection spans)
        {
            return Array.Empty<ITagSpan<ErrorTag>>();
        }

        public void Dispose()
        {
            
        }
    }
}
