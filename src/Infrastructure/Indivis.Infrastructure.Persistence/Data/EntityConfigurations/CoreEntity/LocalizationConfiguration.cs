using Indivis.Core.Application.Common.BaseClasses.EntityFeatureConfigurations;
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

namespace Indivis.Infrastructure.Persistence.Data.EntityConfigurations.CoreEntity
{
    public class LocalizationConfiguration : BaseEntityConfiguration<Localization>
    {
        public override void Configure(EntityTypeBuilder<Localization> builder)
        {
            base.Configure(builder);

            builder.HasIndex(x => x.Key).IsUnique();

            builder.Property(x => x.Key)
                .IsRequired()
                .HasMaxLength(EntityConfigurationConstants.MaxStringLv5);

            builder.Property(x => x.DefaultValue).IsRequired();

            builder.Property(x=>x.IsPageLocalization).HasDefaultValue<bool>(false);

            builder.Property(x=>x.IsHtmlEditor).HasDefaultValue<bool>(false);

            builder.Property(x=>x.IsBackendLocalization).HasDefaultValue<bool>(false);

            builder.HasOne(x => x.Page)
                .WithMany(x => x.Localizations)
                .HasForeignKey(x => x.PageId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
