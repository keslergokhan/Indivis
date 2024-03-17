using Indivis.Core.Application.Interfaces.Data;
using Indivis.Core.Domain.Entities;
using Indivis.Core.Domain.Entities.CoreEntities;
using Indivis.Core.Domain.Entities.CoreEntities.ManyToMany;
using Indivis.Infrastructure.Persistence.Data.EntityConfigurations.CoreEntity;
using Indivis.Infrastructure.Persistence.Identities;
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
    public class IndivisContext : IdentityDbContext<ApplicationUser,ApplicationRole,Guid>, IApplicationDbContext
    {
        public IndivisContext(DbContextOptions<IndivisContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Language> Languages => Set<Language>();
        public DbSet<Url> Urls => Set<Url>();
        public DbSet<Url_UrlSystemType> Url_UrlSystemTypes => Set<Url_UrlSystemType>();
        public DbSet<EntityUrl> EntityUrls => Set<EntityUrl>();
        public DbSet<Entity> Entitys => Set<Entity>();
        public DbSet<Page> Pages => Set<Page>();
        public DbSet<PageSystem> PageSystems => Set<PageSystem>();
        public DbSet<Announcement> Announcements=> Set<Announcement>();
    }
}
