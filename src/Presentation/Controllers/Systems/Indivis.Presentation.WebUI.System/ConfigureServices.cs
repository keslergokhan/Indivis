using Indivis.Core.Application.Common.Data.Presentation;
using Indivis.Core.Application.Interfaces.Data.Presentation;
using Indivis.Presentation.WebUI.System.Middlawares;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Indivis.Core.Application.Common.SystemInitializers;
using Indivis.Core.Application.Attributes.Systems;
using Indivis.Presentation.WebUI.System.Services.DynamicRoutes;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Indivis.Presentation.WebUI.System
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddWebUISystem(this IServiceCollection service)
        {
            service.AddSystemsDependencyRegister(Assembly.GetExecutingAssembly());
            service.AddScoped<SystemRequestAboutMiddleware>();
            service.AddScoped<DefaultDynamicRouteValueTransformer>();
            return service;
        }
    }
}
