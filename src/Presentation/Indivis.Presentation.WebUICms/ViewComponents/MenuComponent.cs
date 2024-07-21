using Microsoft.AspNetCore.Mvc;

namespace Indivis.Presentation.WebUICms.ViewComponents
{
	public class MenuComponent : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("~/Views/ViewComponents/MenuViewComponent.cshtml");
		}
	}
}
