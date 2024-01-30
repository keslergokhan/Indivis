using Indivis.Core.Domain.Commons.CoreEntities;
using Indivis.Core.Domain.Entities.CoreEntities;
using Indivis.Core.Domain.Interfaces.Entities.CoreEntities;
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
    public class LanguageConfiguration : BaseEntityConfiguration<Language>
    {
        public override void Configure(EntityTypeBuilder<Language> builder)
        {
            base.Configure(builder);

            builder.ToTable(typeof(Language).Name);
            builder.Property(x => x.Name)
                .IsRequired(true)
                .HasMaxLength(EntityConfigurationConstants.MaxStringLv1)
                .HasColumnOrder(1);

            builder.Property(x => x.CountryCode)
                .IsRequired(true)
                .HasMaxLength(EntityConfigurationConstants.MaxStringLv0)
                .HasColumnOrder(3);

            builder.Property(x => x.Culture)
                .IsRequired(true)
                .HasMaxLength(EntityConfigurationConstants.MaxStringLv0)
                .HasColumnOrder(5);

            builder.Property(x => x.Currency)
                .IsRequired(true)
                .HasColumnOrder(6);

            builder.Property(x => x.FLag)
                .IsRequired(false)
                .HasMaxLength(EntityConfigurationConstants.MaxStringLv0)
                .HasColumnOrder(7);

            builder.Property(x => x.Sort)
                .IsRequired(true)
                .HasColumnOrder(8);
        }

    }
}
