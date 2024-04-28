using Indivis.Core.Application.Common.SystemInitializers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUI.Widgets
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddWebUIWidgets(this IServiceCollection services)
        {
            AssemblySharedSystemsInitializer.Instance.AddSystemsDependencyRegister(Assembly.GetExecutingAssembly(),services);
            return services;
        }
    }
}
