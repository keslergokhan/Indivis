using Indivis.Core.Application.Common.Constants.Systems;
using Indivis.Core.Application.Common.Data;
using Indivis.Core.Application.Interfaces.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

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
		/// namespace Indivis.Core.Application.EntityFeatureConfigurations altında bulunan BaseEntityFeatureConfiguration<>
        /// tanımlamlarını tespit eder ve DI kayıtlarını gerçekleştirir.
		/// </summary>
		/// <param name="assembly"></param>
		/// <param name="serviceCollection"></param>
		public void AddAssemblySystemEntityFeatures(Assembly assembly,IServiceCollection serviceCollection)
        {
            foreach (Type type in 
                assembly.GetTypes()?
                .Where(x => x.BaseType != null && x.BaseType.IsGenericType && x.BaseType.GetGenericTypeDefinition() == SystemClassTypeConstant.Instance.BaseEntityFeatureConfiguration)
                ?.ToList())
            {
                serviceCollection.AddScoped(type);
            }
        }

		/// <summary>
		/// IFeatureQueryFactory arayüzünü implemente etmiş olan MediatR query sınıflarının DI kayıt sürecini yürütür.
		/// </summary>
		/// <param name="assembly"></param>
		/// <param name="serviceCollection"></param>
		public void AddAssemblyFeatureQueryFactory(Assembly assembly,IServiceCollection serviceCollection)
        {
            assembly.GetTypes()?
                .ToList()
                .Where(type => type.GetInterface(SystemClassTypeConstant.Instance.IFeatureQueryFactory.Name) is not null)
                ?.ToList().ForEach(type =>
                {
                    Type interfaceType = type.GetInterface(SystemClassTypeConstant.Instance.IFeatureQueryFactory.Name);
                    Type[] types = interfaceType.GetGenericArguments();
                    Type queryType = types.FirstOrDefault();
                    serviceCollection.AddSingleton(queryType);
                });
        }
        
    }
}
