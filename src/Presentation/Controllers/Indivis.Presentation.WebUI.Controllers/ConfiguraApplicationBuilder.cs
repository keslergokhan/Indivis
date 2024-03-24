using Indivis.Presentation.WebUI.System;
using Indivis.Presentation.WebUI.System.Services.DynamicRoutes;
using Microsoft.AspNetCore.Builder;

namespace Indivis.Presentation.WebUI.Controllers
{
	public static class ConfiguraApplicationBuilder
	{
		public static IApplicationBuilder AddWebUIController(this IApplicationBuilder app)
		{
			app.AddSystemWebUIApplication();
			return app;
		}

		public static IApplicationBuilder WebUIDynamicUseEndpoints(this IApplicationBuilder app)
		{
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapDynamicControllerRoute<DefaultDynamicRouteValueTransformer>("{**slug}");

			});
			return app;
		}
	}
}
