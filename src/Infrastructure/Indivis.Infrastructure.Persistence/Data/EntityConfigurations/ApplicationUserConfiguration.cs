using Indivis.Infrastructure.Persistence.Constans;
using Indivis.Infrastructure.Persistence.Identities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Infrastructure.Persistence.Data.EntityConfigurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(EntityConfigurationConstants.MaxStringLv3);
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(EntityConfigurationConstants.MaxStringLv3);
        }
    }
}
