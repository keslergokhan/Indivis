﻿using AutoMapper;
using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Domain.Entities.CoreEntities;
using System.Reflection;

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


        /// <summary>
        /// Method içerisine gönderilen Assembly içerisinde CraeteMapAttribute tanımlanmış sınıflara ulaşır.
        /// Sınıf üzerindeki tanımlanmış CreateMap gönderilmiş olan type değerlerini IMapperConfiguration içerisine ekler<br></br>
        /// 
        /// Daha fazlası : README_SYSTEM_INITIALİZER.md
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="mapperConfiguration"></param>
        public void AddAssemblySystemCreateMapper(Assembly assembly, IMapperConfigurationExpression mapperConfiguration)
        {
            //assembly içerisinde CreateMapAttribute tanımlanmış type değerlerini getir.
            assembly.GetTypes()?.Where(type => type.GetCustomAttribute<CreateMapAttribute>() is not null)?.ToList().ForEach(classType =>
            {
                CreateMapAttribute attr = classType.GetCustomAttribute<CreateMapAttribute>();

                if (attr.DestinationTypes.Length > 0)
                {
                    //içerisine tanımlanmış type değerlerini gez.
                    attr.DestinationTypes.ToList().ForEach(DTypeClass =>
                    {
                        //çift taraflı tanımlama uygula
                        //AObject -> BObject || BObject -> AObject
                        mapperConfiguration.CreateMap(classType, DTypeClass).ReverseMap();

                        mapperConfiguration.CreateMap<Page, Language>();
                    });
                }
            });
        }

    }
   
}
