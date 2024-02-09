using AutoMapper;
using Indivis.Core.Application.Attributes.System;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Pages.Reads;
using Indivis.Core.Domain.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Common.SystemInitializers
{
    public class AssemblyMapperInitializer
    {
        private AssemblyMapperInitializer()
        {
            
        }

        public static AssemblyMapperInitializer Instance => AssemblyMapperInitializer.CreateInstance.Value;
        private static readonly Lazy<AssemblyMapperInitializer> CreateInstance = new Lazy<AssemblyMapperInitializer>(() =>
        {
            return new AssemblyMapperInitializer();
        });

       

        public void AssemblyCreateMapper(Assembly assembly, IMapperConfigurationExpression mapperConfiguration)
        {
            assembly.GetTypes()?.Where(type => type.GetCustomAttribute<CreateMapAttribute>() is not null)?.ToList().ForEach(classType =>
            {
                CreateMapAttribute attr = classType.GetCustomAttribute<CreateMapAttribute>();

                if (attr.DestinationTypes.Length > 0)
                {
                    attr.DestinationTypes.ToList().ForEach(DTypeClass =>
                    {
                        mapperConfiguration.CreateMap(classType, DTypeClass).ReverseMap();
                    });
                }
            });
        }

    }
   
}
