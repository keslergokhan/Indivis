using Indivis.Core.Application.Common.Constants.Systems;
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


        public void AddAssemblySystemCoreQueries(Assembly assembly,IServiceCollection serviceDescriptors)
        {
           
            foreach (Type classType in assembly.GetTypes().Where(x => x.GetInterface(SystemClassTypeConstant.Instance.IGetByIdEntityQuery.Name) is not null))
            {
                classType.GetInterface(SystemClassTypeConstant.Instance.IGetByIdEntityQuery.Name);
            }
        }

      
    }
}
