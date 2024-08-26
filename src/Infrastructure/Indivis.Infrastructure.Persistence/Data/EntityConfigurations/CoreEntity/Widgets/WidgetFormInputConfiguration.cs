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
    public class WidgetFormInputConfiguration : BaseEntityConfiguration<WidgetFormInput>
    {
        public override void Configure(EntityTypeBuilder<WidgetFormInput> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(EntityConfigurationConstants.MaxStringLv3);
            builder.Property(x=>x.Required).HasDefaultValue<bool>(false);
            builder.Property(x => x.InputComponentName).IsRequired(true).HasMaxLength(EntityConfigurationConstants.MaxStringLv3);


        }
    }
}
