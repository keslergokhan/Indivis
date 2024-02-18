using Indivis.Core.Application.Common.Data.Presentation;
using Indivis.Core.Application.Interfaces.Data.Presentation;
using Indivis.Presentation.WebUI.System.Middlawares;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUI.System
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddWebUISystem(this IServiceCollection service)
        {
            service.AddSingleton<ICurrentRequest, CurrentRequest>();    
            service.AddTransient<SystemRequestAboutMiddleware>();
            return service;
        }
    }
}
