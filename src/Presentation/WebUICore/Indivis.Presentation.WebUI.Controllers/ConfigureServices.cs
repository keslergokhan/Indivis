using Microsoft.Extensions.DependencyInjection;
using Indivis.Presentation.WebUI.System;

namespace Indivis.Presentation.WebUI.Controllers
{
	public static class ConfigureServices
	{
		public static IServiceCollection AddWebUIController(this IServiceCollection service)
		{
			service.AddWebUISystem();
			return service;
		}
	}
}
