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




        public T GetByNameApplicationInjectionType<T>(IServiceProvider serviceProvider, string objectName) where T : class, IUrlSystemType
        {
            return this.GetByNameInjectionType<T>(Assembly.GetExecutingAssembly(),serviceProvider,objectName);
        }

        public T GetByNameInjectionType<T>(Assembly assembly, IServiceProvider serviceProvider, string objectName) where T : class, IUrlSystemType
        {
            Type objectType = assembly.GetTypes().FirstOrDefault(x => x.Name == objectName);
            if (objectType!=null)
            {
                return (T)serviceProvider.GetService(objectType);
            }
            return null;
        }

        public Type GetAssemblyType(Assembly assembly,string objectName) 
        {
            return assembly.GetTypes().FirstOrDefault(x => x.Name == objectName);
        }

        public async Task<object> GeMethodInvokeAsync(Type classType, string methodName,IServiceProvider serviceProvider, params object[] parameters)
        {
            object serviceObject = serviceProvider.GetService(classType);

            MethodInfo methodInfo = serviceObject.GetType().GetMethod(methodName);

            object methodResult = null;
            if (SystemDependencyInjection.Instance.IsAsyncMethod(methodInfo))
            {
                dynamic invokeResult = methodInfo.Invoke(serviceObject, SystemDependencyInjection.Instance.MethodParametersCreate(methodInfo, serviceProvider, parameters).ToArray());
                methodResult = await invokeResult;
            }
            else
            {
                methodResult = methodInfo.Invoke(serviceObject, SystemDependencyInjection.Instance.MethodParametersCreate(methodInfo, serviceProvider, parameters).ToArray());
            }


            return methodResult;
        }


        /// <summary>
        /// İletilen MethodInfo değerini oluştururken parametreleri IServiceProvider araclığı ile set eder.
        /// </summary>
        /// <param name="methodInfo"></param>
        /// <param name="serviceProvider"></param>
        /// <param name="customParams"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public List<object> MethodParametersCreate(MethodInfo methodInfo, IServiceProvider serviceProvider, params object[] customParams)

        {
            List<object> args = new List<object>();

            if (methodInfo != null)
            {
                methodInfo.GetParameters()?.ToList().ForEach(param =>
                {
                    //istenilen parametre serviste varsa getir
                    if (!customParams.Any(x => x.GetType() != param.ParameterType) && serviceProvider.GetService(param.ParameterType) != null)
                    {
                        args.Add(serviceProvider.GetService(param.ParameterType));
                    }
                    else
                    {
                        //istenilen parametre gönderilen dizi içerisinde varsa onu ekle 
                        object getParamsResult = customParams.Where(x => x.GetType() == param.ParameterType || x.GetType().GetInterface(param.ParameterType.Name) != null).FirstOrDefault();

                        if (getParamsResult != null)
                            args.Add(getParamsResult);
                    }

                });
            }
            else
                throw new ArgumentNullException($"methodInfo değeri boş olamaz !");

            return args;
        }

        /// <summary>
        /// Methodu asenkron olup olmadığını kontrol eder.
        /// </summary>
        /// <param name="methodInfo"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool IsAsyncMethod(MethodInfo methodInfo)
        {
            if (methodInfo == null)
                throw new ArgumentNullException("Çalıştırılacak bir Method bulamadım !");

            // Methodun geri dönüş tipini alalım
            Type returnType = methodInfo.ReturnType;

            // Geri dönüş tipi Task veya Task<T> ise method asenkron olarak kabul edilir
            if (returnType != null && (returnType == typeof(System.Threading.Tasks.Task) || returnType.IsGenericType && returnType.GetGenericTypeDefinition() == typeof(System.Threading.Tasks.Task<>)))
            {
                return true;
            }

            return false;
        }

    }
}
