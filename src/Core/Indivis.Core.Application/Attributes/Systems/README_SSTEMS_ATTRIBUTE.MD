# CreateMapAttribute

## Süreç
Proje içerisinde AutoMapper kullanılmıştır.

Proje içerisinde AutoMapper kullanabilmemiz için dönüştürülecek olan tiplerin AutoMapper arayüzleri aracılığı ile configurasyonları yapılması gerekmektedir.
Örnek:

`CreateMap<User, UserDto>();`

Yukarıdaki örnekte User nesnesinin UserDto dönüştürüleceğini sisteme belirtmiş olduk, bu tanımlama sayesinde aşağıdaki gibi bir kullanım gerçekleştirebiliyoruz.

`_mapper.Map<UserDto>(user)`

Yukarıdaki örnekte tanımlamasını yaptığımız User tipindeki nesnelerin UserDto tipine dönüştürülmesini mapper aracılığı ile yapıyoruz.

## Problem

Bu süreci kullanacağımız tüm dto sınıfları için uygulamamız gerekmektedir, başlangıç süreçlerinde oldukça basit gelsede zaman ilerledikçe gereksiz şekilde profile sınıfları ve satırlarca Craete tanımlamalrını kullanmak zorunda kalıyoruz.

**CreateMapAttribute**  bu süreçlerin otomatikleşmesi için yapılmış özel bir attributes sınıfıdır.

## Kullanım ve Çözüm

    [CreateMap(typeof(Page))]
    public partial class ReadPageDto : BaseReadEntityDto
    {
        public string Name { get; set; }
        public Guid UrlId { get; set; }
        public ReadUrlDto Url { get; set; }
    }


Yukarıdaki örnek ile ReadPageDto sınıfının hangi Type yapılarına dönüştürülebileceğini belirtiyoruz, bu işlem bize `Create<ReadPageDto,Page>()` ve `Create<Page,ReadPageDto>()` yapmak ile aynı şeye denk geliyor.
Bizim yerimize otomatik olarak reflection ile süreci kendi yürütecek, artık manuel şekilde Create methodlarını kendimiz tek tek yazmamıza gerek yok ihtiyaç duyulan sıfın üzerine tanımlamarın yapılması yeterli.

NOT: Attributes değerleri mapping içerisinde nasıl set ediliyor hakkında daha fazla bilgi almak için aşağıdaki yerlere göz atınız.

1. \src\Core\Indivis.Core.Application\Common\SystemInitializers\AssemblyMapperInitializer.cs
2. README_SYSTEM_INITIALİZER.md


<hr>