﻿using Indivis.Core.Domain.Entities.CoreEntities.Widgets;
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
    public class WidgetServiceConfiguration : BaseEntityConfiguration<WidgetService>
    {
        public override void Configure(EntityTypeBuilder<WidgetService> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.WidgetServiceClassName)
                .HasMaxLength(EntityConfigurationConstants.MaxStringLv4)
                .IsRequired(true)
                .HasColumnOrder(1);

            builder.Property(x=>x.MethodName)
                .IsRequired(true)
                .HasMaxLength (EntityConfigurationConstants.MaxStringLv4)
                .HasColumnOrder(2);
        }
    }
}
