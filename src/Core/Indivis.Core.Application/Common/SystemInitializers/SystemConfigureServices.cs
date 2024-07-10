﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

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

        }

        public static void AddAssemblySystemEntityFeatures(this IServiceCollection services, Assembly assembly)
        {
            AssemblyCoreEntityFeatureInitializer.Instance.AddAssemblySystemEntityFeatures(assembly,services);
        }

        public static void AddAssemblyFeatureQueryFactory(this IServiceCollection services, Assembly assembly)
        {
            AssemblyCoreEntityFeatureInitializer.Instance.AddAssemblyFeatureQueryFactory(assembly,services);
        }

        public static void AddSystemsDependencyRegister(this IServiceCollection services, Assembly assembly)
        {
            AssemblySharedSystemsInitializer.Instance.AddSystemsDependencyRegister(assembly,services);
        }

       
    }
}
