using Indivis.Core.Domain.Entities.CoreEntities;
using Indivis.Core.Domain.Entities.CoreEntities.ManyToMany;
using Indivis.Core.Domain.Entities.CoreEntities.Widgets;
using Indivis.Core.Domain.Interfaces.Entities.CoreEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Interfaces.Data
{
    public interface IApplicationDbContext
    {
        new DbSet<TEntity> Set<TEntity>() where TEntity : class;
        public DbSet<Language> Languages { get; }
        public DbSet<Url> Urls { get; }
        //public DbSet<Url_UrlSystemType> Url_UrlSystemTypes { get; }
        public DbSet<EntityUrl> EntityUrls { get; }
        public DbSet<Entity> Entitys { get; }
        public DbSet<Page> Pages { get; }
        public DbSet<PageSystem> PageSystems { get; }
        public DbSet<Widget> Widgets { get; }
        public DbSet<PageZone> PageZones { get; }
        public DbSet<PageWidget> PageWidgets { get; }
        public DbSet<PageWidgetSetting> PageWidgetSettings { get; }
        public DbSet<WidgetService> WidgetServices { get; }
        public DbSet<WidgetTemplate> WidgetTemplates { get; }
        public DbSet<WidgetForm> WidgetForms { get; }
        public DbSet<WidgetFormInput> WidgetFormInputs { get; }
        public DbSet<Localization> Localization { get; }
        public DbSet<LocalizationRegion> LocalizationRegions { get; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
