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
    public class WidgetConfiguration : BaseEntityLanguageConfiguration<Widget>
    {
        public override void Configure(EntityTypeBuilder<Widget> builder)
        {
            base.Configure(builder);


            builder.Property(x => x.Name)
                .HasMaxLength(EntityConfigurationConstants.MaxStringLv4)
                .IsRequired(true)
                .HasColumnOrder(1);

            builder
                .Property(x => x.Description)
                .HasMaxLength(EntityConfigurationConstants.MaxStringLv6)
                .HasColumnOrder(2);

            builder.Property(x=>x.Image)
                .HasMaxLength(EntityConfigurationConstants.MaxStringLv5)
                .HasColumnOrder(3);

            builder
                .Property(x => x.Order)
                .HasDefaultValue(0)
                .HasColumnOrder(5);

            builder
                .HasMany(x => x.WidgetTemplates)
                .WithOne(x => x.Widget)
                .HasForeignKey(x => x.WidgetId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
