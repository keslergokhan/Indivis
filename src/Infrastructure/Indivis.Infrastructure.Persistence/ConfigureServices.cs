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
using System.Reflection;
using Indivis.Core.Application.Common.Constants.Systems;
using System.Runtime.CompilerServices;
using Indivis.Core.Domain.Entities.CoreEntities.Widgets;
using Microsoft.AspNetCore.Identity;
using Indivis.Core.Application.Common.SystemInitializers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;

namespace Indivis.Infrastructure.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,IConfiguration configuration)
        {
            
            services.AddDbContext<IndivisContext>(x=>x.UseSqlServer(configuration.GetConnectionString("default2")));

            services.AddScoped<IApplicationDbContext>(sp =>
            sp.GetRequiredService<IndivisContext>());

            services.AddIdentity<ApplicationUser, ApplicationRole>().AddEntityFrameworkStores<IndivisContext>().AddDefaultTokenProviders();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.Cookie.Name = "indivis.Auth";
                options.LoginPath = "/AccountCms/Login";
                options.Cookie.HttpOnly = true;
                options.AccessDeniedPath = "/AccountCms/Login";
            });
            
            services.AddDataProtection().SetApplicationName("Indivis").PersistKeysToDbContext<IndivisContext>();
            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, CustomUserClaimsPrincipalFactory>();


            services.AddSystemsDependencyRegister(Assembly.GetExecutingAssembly());

            //Identitty(services);
            //Run(services);
            return services;
        }


        public static void Identitty(IServiceCollection services)
        {
            UserManager<ApplicationUser> userManager = services.BuildServiceProvider().GetService<UserManager<ApplicationUser>>();
            RoleManager<ApplicationRole> roleManager = services.BuildServiceProvider().GetService<RoleManager<ApplicationRole>>();
            
            ApplicationRole role = new ApplicationRole()
            {
                Name = "BaseAdmin",
                NormalizedName = "BASEADMIN",
            };

            roleManager.CreateAsync(role);


            var passwordHasher = new PasswordHasher<object>();

            string email = "gokhan@gmail.com";
            ApplicationUser user = new ApplicationUser()
            {
                Email = email,
                NormalizedEmail = email.ToUpper(),
                UserName = email,
                NormalizedUserName = email.ToUpper(),
                Name = "Gökhan",
                EmailConfirmed = true,
                Surname = "Kesler",
                
            };

            user.Id = Guid.NewGuid();

            userManager.CreateAsync(user,"Gokhan.123").Wait();

            userManager.AddToRoleAsync(user,"BaseAdmin");
            

            

            
        }

        public static void Run(IServiceCollection services)
        {
            IndivisContext db = services.BuildServiceProvider().GetService<IndivisContext>();

            

            //AddLanguage(db);

            //AddEntity(db);

            AddUrlSystemType(db);

            AddPageSystem(db);

            AddPage(db);

            //AddWidget(db);

            //AddPageZone(db);

            AddPageAnnouncement(db);

            AddPageAnnouncementDetail(db);

            AnnouncementEntity(db);
            
        }


        public static Language GetLanguageTr(IndivisContext db)
        {
            return db.Set<Language>().FirstOrDefault(x => x.CountryCode == "TR");
        }



        public static void AddLanguage(IndivisContext db)
        {
            if (!db.Set<Language>().Any(x => x.FLag == "TR"))
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
            }
            db.SaveChanges();

        }
        public static void AddEntity(IndivisContext db)
        {
            Assembly domainAssembly = Assembly.Load("Indivis.Core.Domain");

            IQueryable<Entity> entityTable = db.Set<Entity>().AsNoTracking().AsQueryable();

            domainAssembly.GetTypes()
                .Where(x => x.GetInterface(SystemClassTypeConstant.Instance.IEntity.Name) != null)
                .ToList()
                .ForEach(x =>
                {
                    bool isEntity = entityTable.Any(a => a.TypeName == x.Name);

                    if (!isEntity)
                    {
                        db.Add(new Entity()
                        {
                            Id = Guid.NewGuid(),
                            CreateDate = DateTime.Now,
                            IsUrlData = false,
                            State = 1,
                            TypeName = x.Name
                        });
                    }
                });

            db.SaveChanges();

        }
        public static void AddUrlSystemType(IndivisContext db)
        {
            IQueryable<UrlSystemType> urlSystemType = db.Set<UrlSystemType>().AsNoTracking();

            if (!db.Set<UrlSystemType>().Any(x => x.InterfaceType == "IUrlSystemType"))
            {
                db.Add(new UrlSystemType()
                {
                    Id = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    InterfaceType = "IUrlSystemType",

                    State = 1,
                });
            }


            if (!db.Set<UrlSystemType>().Any(x => x.InterfaceType == "IPageUrlSystemType"))
            {
                db.Add(new UrlSystemType()
                {
                    Id = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    InterfaceType = "IPageUrlSystemType",
                    State = 1,
                });
            }

            if (!db.Set<UrlSystemType>().Any(x => x.InterfaceType == "IEntityUrlSystemType"))
            {
                db.Add(new UrlSystemType()
                {
                    Id = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    InterfaceType = "IEntityUrlSystemType",
                    State = 1,

                });
            }


            if (!db.Set<UrlSystemType>().Any(x => x.InterfaceType == "IEntityListUrlSystemType"))
            {
                db.Add(new UrlSystemType()
                {
                    Id = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    InterfaceType = "IEntityListUrlSystemType",
                    State = 1,
                });
            }





            db.SaveChanges();

        }
        public static void AddPageSystem(IndivisContext db)
        {
            PageSystem pageSystem = new PageSystem()
            {
                Id = Guid.NewGuid(),
                Name = "Announcement Liste",
                Controller = "AnnouncementController",
                Action = "List",
                Description = "Duyurular Liste Sayfa Sistemi",
                Pages = new Collection<Page>(),
                UrlSystemType = db.UrlSystemTypes.FirstOrDefault(x => x.InterfaceType == "IEntityListUrlSystemType"),
                IsEntity = false,
                State = 1,
                CreateDate = DateTime.Now
            };

            if (!db.Set<PageSystem>().Any(x => x.Controller == "AnnouncementController"))
            {
                db.Set<PageSystem>().Add(pageSystem);
            }

            PageSystem pageSystem2 = new PageSystem()
            {
                Id = Guid.NewGuid(),
                Name = "PageContent",
                Controller = "PageContentController",
                Action = "PageContent",
                Description = "Boş sayfa taslağı",
                Pages = new Collection<Page>(),
                UrlSystemType = db.UrlSystemTypes.FirstOrDefault(x => x.InterfaceType == "IPageUrlSystemType"),
                State = 1,
                CreateDate = DateTime.Now
            };

            if (!db.Set<PageSystem>().Any(x => x.Controller == "PageContentController"))
            {
                db.Set<PageSystem>().Add(pageSystem2);
            }

            PageSystem pageSystem3 = new PageSystem()
            {
                Id = Guid.NewGuid(),
                Name = "Announcement Detail",
                Controller = "AnnouncementController",
                Action = "Detail",
                Description = "Duyurular Detay Sayfa Sistemi",
                Pages = new Collection<Page>(),
                UrlSystemType = db.UrlSystemTypes.FirstOrDefault(x => x.InterfaceType == "IEntityUrlSystemType"),
                IsEntity = true,
                State = 1,
                CreateDate = DateTime.Now
            };

            if (!db.Set<PageSystem>().Any(x => x.Controller == "AnnouncementController" && x.Action == "Detail"))
            {
                db.Set<PageSystem>().Add(pageSystem3);
            }


            db.SaveChanges();
        }
        public static void AddPage(IndivisContext db)
        {
            Language language = db.Set<Language>().FirstOrDefault(x => x.FLag == "TR");
            UrlSystemType urlSystemTypePageDefault = db.Set<UrlSystemType>().FirstOrDefault(x => x.InterfaceType == "IPageUrlSystemType");
            PageSystem pageSystem = db.Set<PageSystem>().FirstOrDefault(x => x.Controller == "PageContentController" && x.Action == "PageContent");
            PageSystem announcementList = db.Set<PageSystem>().FirstOrDefault(x => x.Controller == "AnnouncementController" && x.Action == "List");
            PageSystem announcementSystemDetail = db.Set<PageSystem>().FirstOrDefault(x => x.Controller == "AnnouncementController" && x.Action == "Detail");


            Url pageAboutUrl = new Url()
            {
                Id = Guid.NewGuid(),
                CreateDate = DateTime.Now,
                FullPath = "/hakkimizda",
                LanguageId = language.Id,
                ParentUrlId = null,
                IsEntity = false,
                Path = "/hakkimizda",
                UrlSystemType = pageSystem.UrlSystemType,
                UrlSystemTypeId = pageSystem.UrlSystemType.Id,
                State = 1
            };
            Page pageAbout = new Page()
            {
                Id = Guid.NewGuid(),
                LanguageId = language.Id,
                CreateDate = DateTime.Now,
                Name = "Hakkimizda",
                Url = pageAboutUrl,
                PageSystem = pageSystem,
                PageSystemId = pageSystem.Id,
                State = 1,
            };

            









            


            

            IQueryable<Page> page = db.Set<Page>().AsNoTracking();

            if (!page.Any(x => x.Name == "Hakkimizda"))
            {
                db.Set<Page>().Add(pageAbout);
            }

            

            db.SaveChanges();
        }


        public static void AddWidget(IndivisContext db)
        {

            if (!db.Set<Widget>().Any(x=>x.Name == "TestWidget"))
            {
                var ss = db.Set<WidgetTemplate>().AsNoTracking().FirstOrDefault(x=>x.Template == "/TestWidget/TestDefault.cshtml");
                db.Set<WidgetTemplate>().FirstOrDefault(x=>x.Title == "Test Default");
                db.Set<Widget>().Add(new Core.Domain.Entities.CoreEntities.Widgets.Widget()
                {
                    Id = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    Description = "TestWidget",
                    Image = "TestWidget",
                    LanguageId = GetLanguageTr(db).Id,
                    Name = "TestWidget",
                    Order = 1,
                    State = 1,
                    WidgetTemplates = new List<WidgetTemplate>()
                {
                    new WidgetTemplate()
                    {
                        Id = Guid.NewGuid(),
                        CreateDate = DateTime.Now,
                        IsDefault = true,
                        State = 1,
                        Template = "/TestWidget/TestDefault.cshtml",
                        Title = "Test Default",
                        Description = "Test Default",
                        Image = "Test Default",
                        LanguageId = GetLanguageTr(db).Id,
                        WidgetService = new WidgetService()
                        {
                            Id = Guid.NewGuid(),
                            CreateDate = DateTime.Now,
                            WidgetServiceTypeName = "TestWidgetService",
                            State = 1,
                        }
                    }
                }
                });

                db.SaveChanges();
            }
            
        }

        public static void AddPageZone(IndivisContext db)
        {
            Page page1 = db.Set<Page>().FirstOrDefault(x=>x.Name == "Hakkimizda");

            Widget widget = db.Set<Widget>().FirstOrDefault(x => x.Name == "TestWidget");

            if (!db.Set<PageZone>().Any(x=>x.Key == "about-page-top-zone"))
            {
                db.Set<PageZone>().Add(new PageZone()
                {
                    Id = Guid.NewGuid(),
                    Key = "about-page-top-zone",
                    CreateDate = DateTime.Now,
                    LanguageId = GetLanguageTr(db).Id,
                    PageId = page1.Id,
                    State = 1,
                    PageWidgets = new List<PageWidget>()
                    {
                        new PageWidget()
                        {
                            Id = Guid.NewGuid(),
                            CreateDate = DateTime.Now,
                            LanguageId= GetLanguageTr(db).Id,
                            State = 1,
                            Widget = widget,
                            PageWidgetSetting = new PageWidgetSetting()
                            {
                                Id = Guid.NewGuid(),
                                ClassCustom = "",
                                CreateDate= DateTime.Now,
                                Grid = "col-12",
                                IsAsync = false,
                                IsShow = false,
                                Order = 1,
                                State = 1,
                            }
                        }
                    }

                });

                db.SaveChanges();
            }

            



        }



        public static void AddPageAnnouncement(IndivisContext db)
        {
            Language language = db.Set<Language>().FirstOrDefault(x => x.FLag == "TR");
            UrlSystemType urlSystemTypePageDefault = db.Set<UrlSystemType>().FirstOrDefault(x => x.InterfaceType == "IPageUrlSystemType");
            PageSystem pageSystem = db.Set<PageSystem>().FirstOrDefault(x => x.Controller == "AnnouncementController" && x.Action == "List");

            Url announcement = new Url()
            {
                Id = Guid.NewGuid(),
                CreateDate = DateTime.Now,
                FullPath = "/duyurular",
                LanguageId = language.Id,
                ParentUrlId = null,
                Path = "/duyurular",
                IsEntity = false,
                UrlSystemType = pageSystem.UrlSystemType,
                State = 1
            };
            Page announcementListage = new Page()
            {
                Id = Guid.NewGuid(),
                LanguageId = language.Id,
                CreateDate = DateTime.Now,
                Name = "Duyurular List",
                Url = announcement,
                PageSystem = pageSystem,
                State = 1,
            };


            

            IQueryable<Page> page = db.Set<Page>().AsNoTracking();

            if (!page.Any(x => x.Name == "Duyurular Lis"))
            {
                db.Set<Page>().Add(announcementListage);
            }

            db.SaveChanges();
        }

        public static void AddPageAnnouncementDetail(IndivisContext db)
        {
            Language language = db.Set<Language>().FirstOrDefault(x => x.FLag == "TR");
            UrlSystemType urlSystemTypePageDefault = db.Set<UrlSystemType>().FirstOrDefault(x => x.InterfaceType == "IEntityUrlSystemType");
            PageSystem pageSystem = db.Set<PageSystem>().FirstOrDefault(x => x.Controller == "AnnouncementController" && x.Action == "Detail");

            Url announcementDetail = new Url()
            {
                Id = Guid.NewGuid(),
                CreateDate = DateTime.Now,
                FullPath = "/duyurular",
                LanguageId = language.Id,
                ParentUrlId = null,
                Path = "/duyurular",
                IsEntity = true,
                UrlSystemType = pageSystem.UrlSystemType,
                State = 1
            };
            Page announcementDetailPage = new Page()
            {
                Id = Guid.NewGuid(),
                LanguageId = language.Id,
                CreateDate = DateTime.Now,
                Name = "Duyurular Detay",
                Url = announcementDetail,
                PageSystem = pageSystem,
                State = 1,
            };



            IQueryable<Page> page = db.Set<Page>().AsNoTracking();

            if (!page.Any(x => x.Name == "Duyurular Detay"))
            {
                db.Set<Page>().Add(announcementDetailPage);
            }

            db.SaveChanges();
        }

        public static void AnnouncementEntity(IndivisContext db)
        {
            Url baseUrl = db.Set<Url>().FirstOrDefault(x => x.IsEntity == true);
            PageSystem pageSystem = db.Set<PageSystem>().FirstOrDefault(x => x.Controller == "AnnouncementController" && x.Action == "Detail");
            Language language = db.Set<Language>().FirstOrDefault(x => x.FLag == "TR");

            List<Announcement> announcements = new List<Announcement>()
            {
                new Announcement()
                {
                    Id = Guid.NewGuid(),
                    CreateDate= DateTime.Now,
                    LanguageId = language.Id,
                    Title = "Örnek Duyuru 1",
                    Description = "Örnek Duyuru 2",
                    State = 1,
                    Url = new Url
                    {
                        Id = Guid.NewGuid(),
                        CreateDate = DateTime.Now,
                        FullPath = "/duyurular/ornek-duyuru-2",
                        Path = "/ornek-duyuru-2",
                        LanguageId= language.Id,
                        ParentUrl = null,
                        IsEntity = false,
                        ParentUrlId = baseUrl.Id,
                        UrlSystemType = pageSystem.UrlSystemType,
                        State = 1,
                        
                    }
                }
            };

            db.AddRangeAsync(announcements);
            db.SaveChanges();
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

                //Entity List tipinde
                
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
            PageSystem pageSystemEmpty = db.Set<PageSystem>().FirstOrDefault(x=>x.Controller == "EmptyPageContentController");

            if (!db.Urls.Any(x=>x.FullPath == "/duyurular"))
            {
                PageSystem pageSystem = new PageSystem()
                {
                    Id = Guid.NewGuid(),
                    Name = "İçerik Sayfası",
                    Description = "Doldurulmaya müsait boş sayfa",
                    Controller = "EmptyPageContentController",
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
            PageSystem pageSystemEmpty = db.Set<PageSystem>().FirstOrDefault(x => x.Controller == "EmptyPageContentController");
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
