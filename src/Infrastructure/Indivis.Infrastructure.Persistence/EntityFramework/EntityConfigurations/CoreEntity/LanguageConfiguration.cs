using Indivis.Core.Domain.Commons.CoreEntities;
using Indivis.Core.Domain.Interfaces.Entities;
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
    public class LanguageConfiguration<T> : BaseEntityConfiguration<T> where T : class,ILanguage
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.ToTable(typeof(T).Name);
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
