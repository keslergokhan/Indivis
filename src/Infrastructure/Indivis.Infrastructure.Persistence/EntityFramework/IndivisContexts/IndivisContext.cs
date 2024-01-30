using Indivis.Core.Domain.Entities.CoreEntities;
using Indivis.Core.Domain.Entities.CoreEntities.ManyToMany;
using Indivis.Infrastructure.Persistence.EntityFramework.EntityConfigurations.CoreEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Infrastructure.Persistence.EntityFramework.IndivisContexts
{
    public class IndivisContext : DbContext
    {
        public IndivisContext(DbContextOptions<IndivisContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Language> Languages { get; set; }
        public DbSet<Url> Urls { get; set; }
        public DbSet<Url_UrlSystemType> Url_UrlSystemType { get; set; }
        public DbSet<EntityUrl> EntityUrls { get; set; }
        public DbSet<Entity> Entity { get; set; }
        public DbSet<Page> Pages { get; set; }
    }
}
