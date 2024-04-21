using Indivis.Core.Domain.Entities.CoreEntities.Widgets;
using Indivis.Infrastructure.Persistence.Commons.EntityFramework.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Infrastructure.Persistence.Data.EntityConfigurations.CoreEntity.Widgets
{
    public class WidgetTemplateConfiguration : BaseEntityConfiguration<WidgetTemplate>
    {
        public override void Configure(EntityTypeBuilder<WidgetTemplate> builder)
        {
            base.Configure(builder);



            builder.Property(x => x.Title)
                .IsRequired(true)
                .HasMaxLength(Constans.EntityConfigurationConstants.MaxStringLv5)
                .HasColumnOrder(0);

            builder.Property(x => x.Template)
                .IsRequired(true)
                .HasMaxLength(Constans.EntityConfigurationConstants.MaxStringLv5)
                .HasColumnOrder(1);

            builder.Property(x => x.Description)
                .IsRequired(false)
                .HasMaxLength(Constans.EntityConfigurationConstants.MaxStringLv5)
                .HasColumnOrder(2);

            builder.Property(x => x.IsDefault)
                .IsRequired(true)
                .HasColumnOrder(3)
                .HasDefaultValue<bool>(true);

            base.ImageConfigure(builder);


            builder.HasOne(x => x.Widget).WithMany(x=>x.WidgetTemplates).HasForeignKey(x=>x.WidgetId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.WidgetService).WithOne()
                .HasForeignKey<WidgetTemplate>(x => x.WidgetServiceId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
