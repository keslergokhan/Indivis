using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Attributes.Systems
{


    /// <summary>
    /// AssemblyMapperInitializer tafafından CraeteMapper sürecinin otomatik yönetilmesi istenilen sınıflar için kullanılır.
    /// constractor içerisine gönderilen type değerlerini reflection aracılığı ile CreateMap tanımlamalarını yapar
    /// Örnek: 
    /// 
    /// Mapping işleminin otomatikleşmesini sağlar.
    /// AObject -> BObject || BObject -> AObject
    /// 
    /// Daha fazlası : README_SYSTEM_INITIALİZER.md
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class CreateMapAttribute : Attribute
    {
        public Type[] DestinationTypes { get; set; }
        public CreateMapAttribute(params Type[] DestinationTypes)
        {
            this.DestinationTypes = DestinationTypes;
        }
    }
}
