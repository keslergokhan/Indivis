using Indivis.Core.Application.Interfaces.Data;
using Indivis.Core.Domain.Entities;
using Indivis.Core.Domain.Entities.CoreEntities;
using Indivis.Core.Domain.Entities.CoreEntities.ManyToMany;
using Indivis.Core.Domain.Entities.CoreEntities.Widgets;
using Indivis.Infrastructure.Persistence.Data.EntityConfigurations.CoreEntity;
using Indivis.Infrastructure.Persistence.Identities;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Infrastructure.Persistence.Data.IndivisContexts
{
    public class IndivisContext : IdentityDbContext<ApplicationUser,ApplicationRole,Guid>, IApplicationDbContext, IDataProtectionKeyContext
    {
        public IndivisContext(DbContextOptions<IndivisContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }


        #region CoreEntity
        public DbSet<Language> Languages => Set<Language>();
        public DbSet<Url> Urls => Set<Url>();
        public DbSet<UrlSystemType> UrlSystemTypes => Set<UrlSystemType>();
        public DbSet<EntityUrl> EntityUrls => Set<EntityUrl>();
        public DbSet<Entity> Entitys => Set<Entity>();
        public DbSet<Page> Pages => Set<Page>();
        public DbSet<PageSystem> PageSystems => Set<PageSystem>();
        public DbSet<Announcement> Announcements => Set<Announcement>();
        #endregion EndCoreEntity

        #region CoreWidgetEntity

        public DbSet<Widget> Widgets => Set<Widget>();
        public DbSet<PageZone> PageZones => Set<PageZone>();
        public DbSet<PageWidget> PageWidgets => Set<PageWidget>();
        public DbSet<PageWidgetSetting> PageWidgetSettings => Set<PageWidgetSetting>();
        public DbSet<WidgetService> WidgetServices => Set<WidgetService>();
        public DbSet<WidgetTemplate> WidgetTemplates => Set<WidgetTemplate>();
        public DbSet<DataProtectionKey> DataProtectionKeys => Set<DataProtectionKey>();
        public DbSet<WidgetForm> WidgetForm => Set<WidgetForm>();
        public DbSet<WidgetFormInput> WidgetFormInput => Set<WidgetFormInput>();
        public DbSet<WidgetForm_WidgetFormInput> WidgetForm_WidgetFormInput => Set<WidgetForm_WidgetFormInput>();
        public DbSet<WidgetForm> WidgetForms => Set<WidgetForm>();
        public DbSet<WidgetFormInput> WidgetFormInputs => Set<WidgetFormInput>();
        public DbSet<Localization> Localization => Set<Localization>();
        public DbSet<LocalizationRegion> LocalizationRegions => Set<LocalizationRegion>();

        #endregion EndCoreWidgetEntity

    }
}
