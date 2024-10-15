using Indivis.Core.Domain.Entities.CoreEntities;
using Indivis.Infrastructure.Persistence.Commons.EntityFramework.EntityConfigurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Infrastructure.Persistence.Data.EntityConfigurations.CoreEntity
{
    public class LocalizationRegionConfiguration : BaseEntityLanguageProConfiguration<LocalizationRegion>
    {
        
        public override void Configure(EntityTypeBuilder<LocalizationRegion> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Value).IsRequired(false);

        }
    }
}
