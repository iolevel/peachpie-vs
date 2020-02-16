using Microsoft.VisualStudio.ProjectSystem.VS.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peachpie.VisualStudio.Extension.ProjectDesigner
{
	/// <summary>
	/// <see cref="IPageMetadata"/> implementation to be used for project property app designer.
	/// </summary>
	sealed class ProjectDesignerPageMetadata : IPageMetadata
    {
		public string Name { get; }

		public bool HasConfigurationCondition { get; }

		public Guid PageGuid { get; }

		public int PageOrder { get; }

		public ProjectDesignerPageMetadata(Guid pageGuid, int pageOrder, bool hasConfigurationCondition)
		{
			if (pageGuid == Guid.Empty)
			{
				throw new ArgumentException(null, nameof(pageGuid));
			}

			PageGuid = pageGuid;
			PageOrder = pageOrder;
			HasConfigurationCondition = hasConfigurationCondition;
		}
	}
}
