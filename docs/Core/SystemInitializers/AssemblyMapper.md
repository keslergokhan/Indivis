
### Görevi
Sınıf CreateMap attributes tanımlanmış sınıflara ulaşır.
Attributes değeri içerisine girilen type değerlerini CreateMap(class,DType) şeklinde IMapperConfiguration arayüzü aracılığı ile tanımlamalarını yapar.



### Süreç

1. AssemblyMapperInitializer.AddAssemblySystemCreateMapper Methodunda assembly ve IMapperConfigurationExpression değerleri iletilir.

3. AddAssemblySystemCreateMapper methodu gönderilen assemblye içerisinde **CreateMap** attrubtes tanımlanan sınıflara reflection ile ulaşır.

5. Ardından attrubtes içerisine girilen type değerlerinin sınıf ile birlikte IMapperConfigurationExpression kullanarak tanımlamaları yapar.




### IServiceCollection kullanımı

    services.AddAutoMapper(x =>
    {
        AssemblyMapperInitializer.Instance.AssemblyCreateMapper(Assembly.GetExecutingAssembly(), x);
    });

### NOT
CreateMapAttributes kaynağı
namespace Indivis.Core.Application.Common.SystemInitializers
[Kod Detayları](https://github.com/keslergokhan/Indivis/blob/master/src/Core/Indivis.Core.Application/Common/SystemInitializers/AssemblyMapperInitializer.cs "Kod Detayları")