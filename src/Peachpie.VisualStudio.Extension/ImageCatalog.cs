using Microsoft.VisualStudio.Imaging.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peachpie.VisualStudio.Extension
{
    static class ImageCatalog
    {
        public static string ImageCatalogGuidString => "8A165441-14AC-4BB8-82C6-BA62A95E99C5";

        public static Guid ImageCatalogGuid => new Guid(ImageCatalogGuidString);

        public static ImageMoniker ProjectIcon => new ImageMoniker { Guid = ImageCatalogGuid, Id = 0 };
    }
}
