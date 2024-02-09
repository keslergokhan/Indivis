# 1) AssemblyMapperInitializer

## GöreviGörevi
Sınıf CreateMap attributes tanımlanmış sınıflara ulaşır.
Attributes değeri içerisine girilen type değerlerini CreateMap(class,DType) şeklinde IMapperConfiguration içerisine ekler.

##Süreç
Dto uygulanacak sınıf için attrubtes tanımlanır


    [CreateMap(typeof(Page))]
    public partial class ReadPageDto : BaseReadEntityDto

Bir sonraki aşama IServiceCollection içerisinde AddAutoMapper içinde sınıfımızı çağırmak ve CreateMap attributeslerimizin olduğu Assembly göndermek



    services.AddAutoMapper(x =>
    {
        AssemblyMapperInitializer.Instance.AssemblyCreateMapper(Assembly.GetExecutingAssembly(), x);
    });