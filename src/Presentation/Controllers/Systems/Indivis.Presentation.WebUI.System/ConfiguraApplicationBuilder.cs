using Indivis.Presentation.WebUI.System.Middlewares;
using Indivis.Presentation.WebUI.System.Services.DynamicRoutes;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUI.System
{
    public static class ConfiguraApplicationBuilder
    {
        public static IApplicationBuilder AddSystemWebUIApplication(this IApplicationBuilder app)
        {
            app.UseMiddleware<SystemRequestAboutMiddleware>();
            return app;
        }
        

	}
}
