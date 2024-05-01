using Indivis.Core.Domain.Entities.CoreEntities;
using Indivis.Infrastructure.Persistence.Commons.EntityFramework.EntityConfigurations;
using Indivis.Infrastructure.Persistence.Constans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Infrastructure.Persistence.Data.EntityConfigurations.CoreEntity
{
    public class PageConfiguration : BaseEntityLanguageConfiguration<Page>
    {
        public override void Configure(EntityTypeBuilder<Page> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Name)
                .HasMaxLength(EntityConfigurationConstants.MaxStringLv5)
                .IsRequired(true);

            builder.HasOne(x => x.Url)
                .WithMany()
                .HasForeignKey(x => x.UrlId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.PageZones)
                .WithOne(x => x.Page)
                .HasForeignKey(x => x.PageId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
