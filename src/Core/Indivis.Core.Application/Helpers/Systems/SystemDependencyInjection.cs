using Indivis.Core.Application.Common.SystemInitializers;
using Indivis.Presentation.WebUI.System.Interfaces.Workers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Helpers.Systems
{
    public class SystemDependencyInjection
    {
        private SystemDependencyInjection()
        {

        }

        public static SystemDependencyInjection Instance => SystemDependencyInjection.CreateInstance.Value;
        private static readonly Lazy<SystemDependencyInjection> CreateInstance = new Lazy<SystemDependencyInjection>(() =>
        {
            return new SystemDependencyInjection();
        });




        public T GetByNameApplicationInjectionType<T>(IServiceProvider serviceProvider, string objectName) where T : class, IUrlSystemTypes
        {
            return this.GetByNameInjectionType<T>(Assembly.GetExecutingAssembly(),serviceProvider,objectName);
        }

        public T GetByNameInjectionType<T>(Assembly assembly, IServiceProvider serviceProvider, string objectName) where T : class, IUrlSystemTypes
        {
            Type objectType = assembly.GetTypes().FirstOrDefault(x => x.Name == objectName);
            if (objectType!=null)
            {
                return (T)serviceProvider.GetService(objectType);
            }
            return null;
        }
    }
}
