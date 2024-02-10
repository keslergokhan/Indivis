using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Indivis.Core.Domain.Entities.CoreEntities;
using Indivis.Core.Domain.Entities.CoreEntities.ManyToMany;
using Indivis.Infrastructure.Persistence.Data.IndivisContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Indivis.Infrastructure.Persistence.Identities;
using Indivis.Core.Application.Interfaces.Data;

namespace Indivis.Infrastructure.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<IndivisContext>(x=>x.UseSqlServer(configuration.GetConnectionString("default2")));

            services.AddScoped<IApplicationDbContext>(sp =>
            sp.GetRequiredService<IndivisContext>());

            services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<IndivisContext>();

            //IndivisContext db = services.BuildServiceProvider().GetService<IndivisContext>();
            //ServiceRegistrations.InsertDbData(db);
            //ServiceRegistrations.ListData(db);

            return services;
        }

        public static void InsertDbData(IndivisContext db)
        {
            using (db)
            {
                var UrlSystemType = new Indivis.Core.Domain.Entities.CoreEntities.UrlSystemType()
                {
                    Id = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    InterfaceType = "IEmptyPage",
                    State = 1,
                };

                var UrlSystemType2 = new Indivis.Core.Domain.Entities.CoreEntities.UrlSystemType()
                {
                    Id = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    InterfaceType = "IEntityList",
                    State = 1,
                };


                db.Set<UrlSystemType>().AddRange(UrlSystemType,UrlSystemType2);


                var language = new Indivis.Core.Domain.Entities.CoreEntities.Language()
                {
                    Id = Guid.NewGuid(),
                    CountryCode = "TR",
                    CreateDate = DateTime.Now,
                    Culture = "tr-TR",
                    Currency = "TL",
                    FLag = "TL",
                    Name = "Türkçe",
                    Sort = 1,
                    State = 1,
                    
                };

                db.Set<Language>().Add(language);


                var url = new Indivis.Core.Domain.Entities.CoreEntities.Url(){
                    Id = Guid.NewGuid(),
                    CreateDate= DateTime.Now,
                    FullPath = "/haberler",
                    Path = "/haberler",
                    LanguageId = language.Id,
                    Url_UrlSystemTypes = new List<Url_UrlSystemType>()
                    {
                        new Url_UrlSystemType()
                        {
                            UrlSystemType = UrlSystemType
                        }
                    },
                    State = 1,
                };

                var url2 = new Indivis.Core.Domain.Entities.CoreEntities.Url()
                {
                    Id = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    FullPath = "/haberler/denemehaber",
                    Path = "/denemehaber",
                    LanguageId = language.Id,
                    ParentUrlId = url.Id,
                    State = 1,
                    Url_UrlSystemTypes = new List<Url_UrlSystemType>()
                    {
                        new Url_UrlSystemType()
                        {
                            UrlSystemType = UrlSystemType
                        }
                    },
                };

                var url3 = new Indivis.Core.Domain.Entities.CoreEntities.Url()
                {
                    Id = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    FullPath = "/haberler/basinbülteni",
                    Path = "/basinbülteni",
                    LanguageId = language.Id,
                    ParentUrlId = url.Id,
                    State = 1,
                    Url_UrlSystemTypes = new List<Url_UrlSystemType>()
                    {
                        new Url_UrlSystemType()
                        {
                            UrlSystemType = UrlSystemType2
                        }
                    },
                };



                db.Set<Url>().AddRange(url,url2,url3);


                db.SaveChanges();


            }   
        }

        public static void ListData(IndivisContext db)
        {
            var deneem = db.Urls.ToList();

            var ffff = db.Urls.Include(x => x.Url_UrlSystemTypes).ToList();

            var ss1 = db.Urls.Include(x => x.SubUrls).ToList();
        }
    }
}
