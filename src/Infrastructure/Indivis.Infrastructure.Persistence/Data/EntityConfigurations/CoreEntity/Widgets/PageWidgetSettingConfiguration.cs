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
    public class PageWidgetSettingConfiguration : BaseEntityConfiguration<PageWidgetSetting>
    {
        public override void Configure(EntityTypeBuilder<PageWidgetSetting> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.ClassCustom)
                .HasMaxLength(Constans.EntityConfigurationConstants.MaxStringLv5)
                .IsRequired(false);

            builder.Property(x => x.Grid)
                .HasMaxLength(Constans.EntityConfigurationConstants.MaxStringLv4)
                .IsRequired(true)
                .HasDefaultValue<string>("col-12");

            builder.Property(x => x.IsAsync)
                .IsRequired(true)
                .HasDefaultValue(false);

            builder.Property(x=>x.IsShow)
                .IsRequired(true)
                .HasDefaultValue<bool>(false);

            base.OrderConfigure(builder);

        }
    }
}
