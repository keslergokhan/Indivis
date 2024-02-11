# 1) AssemblyMapperInitializer

## Görevi
Sınıf CreateMap attributes tanımlanmış sınıflara ulaşır.
Attributes değeri içerisine girilen type değerlerini CreateMap(class,DType) şeklinde IMapperConfiguration içerisine ekler.

## Süreç
Dto uygulanacak sınıf için attrubtes tanımlanır


    [CreateMap(typeof(Page))]
    public partial class ReadPageDto : BaseReadEntityDto

Bir sonraki aşama IServiceCollection içerisinde AddAutoMapper içinde sınıfımızı çağırmak ve CreateMap attributeslerimizin olduğu Assembly göndermek



    services.AddAutoMapper(x =>
    {
        AssemblyMapperInitializer.Instance.AssemblyCreateMapper(Assembly.GetExecutingAssembly(), x);
    });


## Sonuç

CreateMapAttributes kullanılmış olan tüm sınıflar içerisine gönderilen tipler aracılığı ile dinamik bir şeklide IMapperConfiguration içerisine dahil edilir ve kullanılmaya hazır hale gelir.

`_mapper.Map<ReadPageDto>(page)`


# 2) AssemblyCoreEntityFeatureInitializer

## 2.1 AssemblyCoreEntityFeatureInitializer.AddAssemblySystemCoreQueries

Proje içerisinde ihtiyaç duyulan bussiness iş sürecinin yönetilmesi MediatR aracılığı ile gerçekleştirilmiştir.


















