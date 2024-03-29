﻿using Indivis.Core.Domain.Entities.CoreEntities;
using Indivis.Infrastructure.Persistence.Commons.EntityFramework.EntityConfigurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Infrastructure.Persistence.Data.EntityConfigurations.CoreEntity
{
    public class EntityUrlConfiguration : BaseEntityConfiguration<EntityUrl>
    {
        public override void Configure(EntityTypeBuilder<EntityUrl> builder)
        {
            base.Configure(builder);


            builder.HasOne(x => x.Url)
                .WithMany()
                .HasForeignKey(x => x.UrlId)
                .IsRequired(true)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);

            builder.HasOne(x => x.Entity)
                .WithMany()
                .HasForeignKey(x => x.EntityId)
                .IsRequired(true)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
        }
    }
}
