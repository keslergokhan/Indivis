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

        }

      
    }
}
