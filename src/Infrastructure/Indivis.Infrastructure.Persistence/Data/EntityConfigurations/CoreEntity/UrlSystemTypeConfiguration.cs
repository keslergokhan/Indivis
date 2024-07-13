using Indivis.Core.Domain.Entities.CoreEntities;
using Indivis.Core.Domain.Interfaces.Entities.CoreEntities;
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
    public class UrlSystemTypeConfiguration : BaseEntityConfiguration<UrlSystemType>
    {
        public override void Configure(EntityTypeBuilder<UrlSystemType> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.InterfaceType)
                .HasMaxLength(250)
                .IsRequired(true);

        }
    }
}
