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
    public class UrlConfiguration : BaseEntityLanguageConfiguration<Url>
    {
        public override void Configure(EntityTypeBuilder<Url> builder)
        {
            base.Configure(builder);

            builder.ToTable(typeof(Url).Name);

            builder.Property(x => x.FullPath)
                .IsRequired(true)
                .HasMaxLength(EntityConfigurationConstants.MaxStringLv7);

            builder.Property(x => x.Path)
                .IsRequired(true)
                .HasMaxLength(EntityConfigurationConstants.MaxStringLv7);

            builder.HasOne(x => x.ParentUrl)
                .WithMany(x => x.SubUrls)
                .HasForeignKey(x => x.ParentUrlId)
                .IsRequired(false).OnDelete(DeleteBehavior.NoAction);



        }
    }
}
