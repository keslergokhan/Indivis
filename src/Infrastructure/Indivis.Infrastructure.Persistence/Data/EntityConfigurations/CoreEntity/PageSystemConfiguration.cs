using Indivis.Core.Domain.Entities.CoreEntities;
using Indivis.Infrastructure.Persistence.Commons.EntityFramework.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Infrastructure.Persistence.Data.EntityConfigurations.CoreEntity
{
    public class PageSystemConfiguration : BaseEntityConfiguration<PageSystem>
    {
        public override void Configure(EntityTypeBuilder<PageSystem> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Name)
                .IsRequired(true)
                .HasColumnOrder(1)
                .HasMaxLength(Constans.EntityConfigurationConstants.MaxStringLv4);

            builder.Property(x => x.Description)
                .IsRequired(false)
                .HasColumnOrder(2)
                .HasMaxLength(Constans.EntityConfigurationConstants.MaxStringLv6);

            builder.Property(x => x.Controller)
                .IsRequired(true)
                .HasColumnOrder(3)
                .HasMaxLength(Constans.EntityConfigurationConstants.MaxStringLv3);

            builder.Property(x => x.Action)
                .IsRequired(true)
                .HasColumnOrder(4)
                .HasMaxLength(Constans.EntityConfigurationConstants.MaxStringLv3);

            builder.Property(x => x.IsEntity).IsRequired(true).HasDefaultValue<bool>(false);

            


            builder.HasOne(x=>x.UrlSystemType).WithMany().HasForeignKey(x=>x.UrlSystemTypeId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
