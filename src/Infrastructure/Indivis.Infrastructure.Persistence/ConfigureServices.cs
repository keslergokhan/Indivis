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
using System.Collections.ObjectModel;

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

            IndivisContext db = services.BuildServiceProvider().GetService<IndivisContext>();
            //ConfigureServices.InsertDbData(db);
            //InsertDbDataParentUrl(db);
            //InsertDbPage(db);

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

                PageSystem pageSystem = new PageSystem()
                {
                    Id = Guid.NewGuid(),
                    Name = "Announcement Liste",
                    Controller = "AnnouncementController",
                    Action = "List",
                    Description = "Duyurular Liste Sayfa Sistemi",
                    Pages = new Collection<Page>(),
                    State = 1,
                    CreateDate = DateTime.Now
                };

                pageSystem.Pages.Add(Page);
                db.Set<PageSystem>().Add(pageSystem);

                db.SaveChanges();

            }   
        }

        public static void InsertDbDataParentUrl(IndivisContext db)
        {
            Language language = db.Set<Language>().FirstOrDefault(x => x.CountryCode == "TR");
            PageSystem pageSystemEmpty = db.Set<PageSystem>().FirstOrDefault(x=>x.Controller == "EmptyPageController");

            if (!db.Urls.Any(x=>x.FullPath == "/duyurular"))
            {
                PageSystem pageSystem = new PageSystem()
                {
                    Id = Guid.NewGuid(),
                    Name = "İçerik Sayfası",
                    Description = "Doldurulmaya müsait boş sayfa",
                    Controller = "EmptyPageController",
                    Action = "Default",
                    State = 1,
                    CreateDate = DateTime.Now
                };
                db.Set<PageSystem>().Add(pageSystem);


                Url url = new Url()
                {
                    Id = Guid.NewGuid(),
                    FullPath = "/kurumsal",
                    LanguageId = language.Id,
                    Path = "/kurumsal",
                    State = 1,
                    CreateDate = DateTime.Now
                };
                db.Set<Url>().Add(url);

                Page page = new Page()
                {
                    Id = Guid.NewGuid(),
                    Name = "Kurumsal",
                    Url = url,
                    LanguageId = language.Id,
                    CreateDate = DateTime.Now,
                    PageSystem = pageSystem,
                    State = 1,
                };
                db.Set<Page>().Add(page);
            }
            


            db.SaveChanges();
        }

        public static void InsertDbPage(IndivisContext db)
        {
            Language language = db.Set<Language>().FirstOrDefault(x => x.CountryCode == "TR");
            PageSystem pageSystemEmpty = db.Set<PageSystem>().FirstOrDefault(x => x.Controller == "EmptyPageController");
            Url parentUrl = db.Set<Url>().FirstOrDefault(x=>x.FullPath == "/kurumsal");

            Url url = new Url()
            {
                Id = Guid.NewGuid(),
                FullPath = "/kurumsal/hakkimizda",
                LanguageId = language.Id,
                Path = "/hakkimizda",
                ParentUrl = parentUrl,
                State = 1,
                CreateDate = DateTime.Now
            };
            db.Set<Url>().Add(url);

            Page page = new Page()
            {
                Id = Guid.NewGuid(),
                Name = "Hakkimizda",
                Url = url,
                LanguageId = language.Id,
                CreateDate = DateTime.Now,
                PageSystem = pageSystemEmpty,
                State = 1,
            };
            db.Set<Page>().Add(page);
            db.SaveChanges();
        }
    }
}
