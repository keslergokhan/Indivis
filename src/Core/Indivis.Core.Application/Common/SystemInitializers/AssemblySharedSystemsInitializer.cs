using AutoMapper;
using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Common.Constants.Systems;
using Indivis.Core.Application.Exceptions.Systems;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Common.SystemInitializers
{
    public class AssemblySharedSystemsInitializer
    {
        private static readonly Lazy<AssemblySharedSystemsInitializer>
            CreateInstance = new Lazy<AssemblySharedSystemsInitializer>(() =>
            {
                return new AssemblySharedSystemsInitializer();
            });

        public static AssemblySharedSystemsInitializer Instance
        {
            get
            {
                return AssemblySharedSystemsInitializer.CreateInstance.Value;
            }
        }


        public void AddSystemsDependencyRegister(Assembly assembly, IServiceCollection services)
        {

            //Mevcut assembly içerisine tüm type değerlerini kontrolet ve bana sadece 'DependencyRegisterAttribute' özniteliğini uygulayan sınıfları getir
            assembly
                .GetTypes()?
                .Where(x => x.GetCustomAttribute(SystemClassTypeConstant.Instance.DependenctyRegisterAttribute) != null).ToList()?.ForEach(classType =>
            {
                //öznitelik içerisindeki property değerlerine erişmek için özniteliğe eriştik
                DependencyRegisterAttribute dependencyRegisterAttribute = classType.GetCustomAttribute<DependencyRegisterAttribute>();
                //öznitelik de tanımlanan interface tipi sayesinde mevcut class içerisinde uygulanan arabirimlerden ihtiyacımız olanın tipine eriştik
                Type serviceType = classType.GetInterface(dependencyRegisterAttribute.InterfaceType.Name);

                //eğer arabirim bulunamadıysa anlaşılabilmesi için özel bir exception tanımladık.
                if (serviceType == null) {
                    serviceType = classType;
                }

                //ihtiyacımıza göre kayıt işlemi yaptık.
                if (dependencyRegisterAttribute.DependencyTypes == DependencyTypes.Scopet)
                {
                    services.AddScoped(serviceType, classType);
                }
                else if (dependencyRegisterAttribute.DependencyTypes == DependencyTypes.Transient)
                {
                    services.AddTransient(serviceType, classType);
                }
                else if (dependencyRegisterAttribute.DependencyTypes == DependencyTypes.Singleton)
                {
                    services.AddSingleton(serviceType, classType);
                }
                else
                {
                    services.AddScoped(serviceType, classType);
                }

            });
        }

    }
}
