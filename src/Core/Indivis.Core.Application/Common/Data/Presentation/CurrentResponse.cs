using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Pages.Reads;
using Indivis.Core.Application.Interfaces.Data.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Common.Data.Presentation
{
	[DependencyRegister(typeof(ICurrentResponse),DependencyTypes.Scopet)]
	public class CurrentResponse : ICurrentResponse
	{
		public ReadPageDto CurrentPage { get; set; }
	}
}
