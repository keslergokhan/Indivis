using Indivis.Core.Domain.Entities;
using Indivis.Infrastructure.Persistence.Commons.EntityFramework.EntityConfigurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Infrastructure.Persistence.Data.EntityConfigurations
{
    public class AnnouncementConfiguration : BaseEntityConfiguration<Announcement>
    {
        public override void Configure(EntityTypeBuilder<Announcement> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Title).HasMaxLength(Persistence.Constans.EntityConfigurationConstants.MaxStringLv5);
            base.SeoConfigure(builder);
            base.SitemapConfigure(builder);
            base.UrlConfigure(builder);
        }
    }
}
