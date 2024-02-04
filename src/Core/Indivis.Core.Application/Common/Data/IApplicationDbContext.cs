using Indivis.Core.Domain.Entities.CoreEntities;
using Indivis.Core.Domain.Entities.CoreEntities.ManyToMany;
using Indivis.Core.Domain.Interfaces.Entities.CoreEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Common.Data
{
    public interface IApplicationDbContext
    {
        new DbSet<TEntity> Set<TEntity>() where TEntity : class;
        public DbSet<Language> Languages { get;}
        public DbSet<Url> Urls { get;}
        public DbSet<Url_UrlSystemType> Url_UrlSystemTypes { get;}
        public DbSet<EntityUrl> EntityUrls { get; }
        public DbSet<Entity> Entitys { get; }
        public DbSet<Page> Pages { get; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
