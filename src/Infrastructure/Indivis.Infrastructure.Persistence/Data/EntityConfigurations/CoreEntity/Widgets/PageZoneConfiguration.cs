using Indivis.Core.Domain.Entities.CoreEntities.Widgets;
using Indivis.Infrastructure.Persistence.Commons.EntityFramework.EntityConfigurations;
using Indivis.Infrastructure.Persistence.Constans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Infrastructure.Persistence.Data.EntityConfigurations.CoreEntity.Widgets
{
    public class PageZoneConfiguration : BaseEntityLanguageConfiguration<PageZone>
    {
        public override void Configure(EntityTypeBuilder<PageZone> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Key)
                .HasMaxLength(EntityConfigurationConstants.MaxStringLv4)
                .IsRequired(true)
                .HasColumnOrder(1);

            builder.HasOne(x=>x.Page)
                .WithMany(x=>x.PageZones)
                .HasForeignKey(x=>x.PageId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
