using Indivis.Core.Domain.Entities.CoreEntities;
using Indivis.Infrastructure.Persistence.EntityFramework.EntityConfigurations.CoreEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Infrastructure.Persistence.EntityFramework.IndivisContexts
{
    public class IndivisContext :DbContext
    {
        public IndivisContext(DbContextOptions<IndivisContext> dbContextOptions):base(dbContextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LanguageConfiguration<Language>());
        }

        public DbSet<Language> Languages { get; set; }
    }
}
