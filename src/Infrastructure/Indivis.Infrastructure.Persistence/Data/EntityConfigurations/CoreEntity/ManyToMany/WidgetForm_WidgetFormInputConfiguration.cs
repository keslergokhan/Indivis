using Indivis.Core.Domain.Entities.CoreEntities.ManyToMany;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Infrastructure.Persistence.Data.EntityConfigurations.CoreEntity.ManyToMany
{
    public class WidgetForm_WidgetFormInputConfiguration : IEntityTypeConfiguration<WidgetForm_WidgetFormInput>
    {
        public void Configure(EntityTypeBuilder<WidgetForm_WidgetFormInput> builder)
        {
            builder.ToTable(nameof(Url_UrlSystemType));
            builder.HasKey(src => new { 
                src.WidgetFormInputId,
                src.WidgetFormId,
            });

            builder.HasOne(x => x.WidgetForm)
                .WithMany(x => x.WidgetForm_WidgetFormInputs)
                .HasForeignKey(x=>x.WidgetFormId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.WidgetFormInput)
                .WithMany(x => x.WidgetForm_WidgetFormInputs)
                .HasForeignKey(x => x.WidgetFormInputId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
