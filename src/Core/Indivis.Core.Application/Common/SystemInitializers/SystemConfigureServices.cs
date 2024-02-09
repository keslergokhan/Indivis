using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Common.SystemInitializers
{
    public static class SystemConfigureServices
    {
        public static void AddSystemMapper(this IServiceCollection services, Assembly assembly)
        {
            services.AddAutoMapper(x =>
            {
                AssemblyMapperInitializer.Instance.AddAssemblySystemCreateMapper(assembly, x);
            });
        }

        public static void AddSystemCoreEntityFeatures(this IServiceCollection services,Assembly assembly)
        {
            AssemblyCoreEntityFeatureInitializer.Instance.AddAssemblySystemCoreQueries(assembly,services);
        }
    }
}
