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

namespace Indivis.Infrastructure.Persistence.EntityFramework.EntityConfigurations.CoreEntity
{
    public class EntityConfiguration : BaseEntityConfiguration<Entity>
    {
        public override void Configure(EntityTypeBuilder<Entity> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.TypeName)
                .HasMaxLength(EntityConfigurationConstants.MaxStringLv4)
                .IsRequired(true)
                .HasColumnOrder(1);

            builder.Property(x => x.IsUrlData).
                HasDefaultValue(false)
                .IsRequired(true)
                .HasColumnOrder(3);


            builder.Property(x => x.EntityDefaultProperty)
                .HasMaxLength(EntityConfigurationConstants.MaxStringLv5)
                .IsRequired(true)
                .HasColumnOrder(5);
        }
    }
}
