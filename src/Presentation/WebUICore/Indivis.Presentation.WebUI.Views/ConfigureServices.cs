using Indivis.Presentation.WebUI.Views.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUI.Views
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddWebUIViews(this IServiceCollection services)
        {
            return services;
        }
    }
}
