using Indivis.Core.Domain.Interfaces.Entities;
using Indivis.Core.Domain.Interfaces.Entities.CoreEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Infrastructure.Persistence.Commons.EntityFramework.EntityConfigurations
{
    public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : class, IEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable(typeof(T).Name);
            builder.Property(x => x.Id).HasColumnOrder(0);

            builder
                .Property(x => x.ModifiedDate)
                .IsRequired(false)
                .HasColumnOrder(999);

            builder
                .Property(x=>x.CreateDate)
                .IsRequired(true)
                .HasColumnOrder(998);

            builder.Property(x => x.State)
                .IsRequired(true)
                .HasColumnOrder(9999);
        }

        protected void ImageConfigure<T>(EntityTypeBuilder<T> builder) where T : class, IEntity, IEntityImage
        {
            builder.Property(x=>x.Image)
                .IsRequired(false)
                .HasMaxLength(Constans.EntityConfigurationConstants.MaxStringLv6)
                .HasColumnOrder(99);
        }

        protected void OrderConfigure<T>(EntityTypeBuilder<T> builder) where T : class, IEntity, IEntityOrder
        {
            builder.Property(x => x.Order)
                .IsRequired(false)
                .HasDefaultValue<int>(1)
                .HasColumnOrder(100);
        }




    }
}
