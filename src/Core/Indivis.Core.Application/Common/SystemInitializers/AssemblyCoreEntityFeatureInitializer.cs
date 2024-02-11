using Indivis.Core.Application.Common.Constants.Systems;
using Indivis.Core.Application.Common.Data;
using Indivis.Core.Application.Interfaces.Data;
using Indivis.Core.Application.Interfaces.Features.Systems;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Common.SystemInitializers
{
    public class AssemblyCoreEntityFeatureInitializer
    {
        private static readonly Lazy<AssemblyCoreEntityFeatureInitializer> 
            CreateInstance = new Lazy<AssemblyCoreEntityFeatureInitializer>(() =>
            {
                return new AssemblyCoreEntityFeatureInitializer();
            });

        public static AssemblyCoreEntityFeatureInitializer Instance 
        { 
            get
            {
                return AssemblyCoreEntityFeatureInitializer.CreateInstance.Value;
            } 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="serviceCollection"></param>
        public void AddAssemblySystemCoreQueries(Assembly assembly,IServiceCollection serviceCollection)
        {
           
            foreach (Type classType in assembly.GetTypes().Where(x => x.GetInterface(SystemClassTypeConstant.Instance.IGetByIdEntityQuery.Name) is not null))
            {
                Type interfaceType = classType.GetInterface(SystemClassTypeConstant.Instance.IGetByIdEntityQuery.Name);
                Type genericEntityType = interfaceType.GenericTypeArguments.FirstOrDefault();

                serviceCollection.AddSingleton(interfaceType, classType);
            }
        }

        public void AddAssemblySystemEntityFeatures(Assembly assembly,IServiceCollection serviceCollection)
        {
            foreach (Type type in 
                assembly.GetTypes()?
                .Where(x => x.BaseType != null && x.BaseType.IsGenericType && x.BaseType.GetGenericTypeDefinition() == SystemClassTypeConstant.Instance.BaseEntityFeatureConfiguration)
                ?.ToList())
            {
                serviceCollection.AddScoped(type);
            }
            serviceCollection.AddScoped<IEntityFeatureContext, EntityFeatureContext>();
        }
        
    }
}
