using Indivis.Core.Domain.Entities.CoreEntities.Widgets;
using Indivis.Infrastructure.Persistence.Commons.EntityFramework.EntityConfigurations;
using Indivis.Infrastructure.Persistence.Constans;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Infrastructure.Persistence.Data.EntityConfigurations.CoreEntity.Widgets
{
    public class WidgetFormConfiguration : BaseEntityConfiguration<WidgetForm>
    {
        public override void Configure(EntityTypeBuilder<WidgetForm> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name)
                .IsRequired(true)
                .HasMaxLength(EntityConfigurationConstants.MaxStringLv3);

            builder.HasOne(x => x.WidgetService)
                .WithMany()
                .HasForeignKey(x=>x.WidgetServiceId)
                .IsRequired()
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
        }
    }
}
