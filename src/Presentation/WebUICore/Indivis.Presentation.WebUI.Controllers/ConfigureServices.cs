using Microsoft.Extensions.DependencyInjection;
using Indivis.Presentation.WebUI.System;
using Indivis.Presentation.WebUI.Widgets;
using Indivis.Presentation.WebUI.Views;

namespace Indivis.Presentation.WebUI.Controllers
{
	public static class ConfigureServices
	{
		public static IServiceCollection AddWebUIController(this IServiceCollection service)
		{
			service.AddWebUISystem();
			service.AddWebUIWidgets();
			service.AddWebUIViews();

            return service;
		}
	}
}
