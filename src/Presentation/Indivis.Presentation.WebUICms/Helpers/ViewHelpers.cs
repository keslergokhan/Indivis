using Indivis.Presentation.WebUICms.Common;
using Indivis.Presentation.WebUICms.Controllers;
using Indivis.Presentation.WebUICms.Models.Helpers;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Indivis.Presentation.WebUICms.Helpers
{
	public class ViewHelpers
	{
		public static ViewHelpers Instance => ViewHelpers._instance.Value;

		private static readonly Lazy<ViewHelpers> _instance = new Lazy<ViewHelpers>(() =>
		{
			return new ViewHelpers();
		});



		
    }
}
