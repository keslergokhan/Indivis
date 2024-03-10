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
using Indivis.Core.Domain.Entities;
using System.IO.Enumeration;
using System.Security.Cryptography;

namespace Indivis.Infrastructure.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<IndivisContext>(x=>x.UseSqlServer(configuration.GetConnectionString("default")));

            services.AddScoped<IApplicationDbContext>(sp =>
            sp.GetRequiredService<IndivisContext>());

            services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<IndivisContext>();

            IndivisContext db = services.BuildServiceProvider().GetService<IndivisContext>();
            //ConfigureServices.InsertDbData(db);

            return services;
        }

        public static void InsertDbData(IndivisContext db)
        {
            using (db)
            {

                //Dil-Türkçe
                Language language = new Language()
                {
                    Id = Guid.NewGuid(),
                    CountryCode = "TR",
                    Culture = "tr-TR",
                    Currency = "TL",
                    FLag = "TR",
                    Name = "Türkçe",
                    Sort = 1,
                    CreateDate = DateTime.Now,
                    State = 1
                };
                db.Set<Language>().Add(language);


                //Announcement
                Entity announcementEntity = new Entity()
                {
                    Id = Guid.NewGuid(),
                    IsUrlData = false,
                    TypeName = "Announcement",
                    CreateDate = DateTime.Now,
                    State = 1
                };
                db.Set<Entity>().Add(announcementEntity);


                //UrlType
                UrlSystemType urlSystemTypeList = new()
                {
                    Id = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    InterfaceType = "IEntityList",
                    State = 1
                };
                db.Set<UrlSystemType>().Add(urlSystemTypeList);

                //duyurular url
                Url announcementUrl = new Url()
                {
                    Id = Guid.NewGuid(),
                    FullPath = "/duyurular",
                    LanguageId = language.Id,
                    Path = "/duyurular",
                    ParentUrl = null,
                    ParentUrlId = null,
                    State = 1,
                    CreateDate = DateTime.Now,
                };

                announcementUrl.Url_UrlSystemTypes = new List<Url_UrlSystemType>();
                //Entity List tipinde
                announcementUrl.Url_UrlSystemTypes.Add(new Url_UrlSystemType()
                {
                    UrlSystemType = urlSystemTypeList,
                });
                db.Set<Url>().Add(announcementUrl);


                EntityUrl announcementEntityUrl = new EntityUrl()
                {
                    Id = Guid.NewGuid(),
                    Url = announcementUrl,
                    Entity = announcementEntity,
                    CreateDate = DateTime.Now,
                    State = 1,
                };
                db.Set<EntityUrl>().Add(announcementEntityUrl);

                Page Page = new Page()
                {
                    Id = Guid.NewGuid(),
                    LanguageId = language.Id,
                    Name = "Duyurular",
                    Url = announcementUrl,
                    State = 1,
                    CreateDate = DateTime.Now
                };
                db.Set<Page>().Add(Page);


                db.SaveChanges();

            }   
        }

        
    }
}
