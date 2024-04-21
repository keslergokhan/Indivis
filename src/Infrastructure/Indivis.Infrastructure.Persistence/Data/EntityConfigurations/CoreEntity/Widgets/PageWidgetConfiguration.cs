using Indivis.Core.Domain.Entities.CoreEntities.Widgets;
using Indivis.Infrastructure.Persistence.Commons.EntityFramework.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Infrastructure.Persistence.Data.EntityConfigurations.CoreEntity.Widgets
{
    public class PageWidgetConfiguration : BaseEntityConfiguration<PageWidget>
    {
        public override void Configure(EntityTypeBuilder<PageWidget> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.PageZone).WithMany(x => x.PageWidgets)
                .HasForeignKey(x => x.PageZoneId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Widget).WithOne()
                .HasForeignKey<PageWidget>(x => x.WidgetId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
