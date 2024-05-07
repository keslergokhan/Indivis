using Indivis.Core.Domain.Entities;
using Indivis.Core.Domain.Entities.CoreEntities;
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
                .IsRequired(true)
                .HasDefaultValue<int>(1)
                .HasColumnOrder(100);
        }


        protected void SeoConfigure<T>(EntityTypeBuilder<T> builder) where T: class, IEntity, IEntitySeo
        {
            builder.Property(x => x.SeoTitle)
                .IsRequired(false)
                .HasColumnOrder(101)
                .HasMaxLength(Constans.EntityConfigurationConstants.MaxStringLv5);

            builder.Property(x => x.SeoBreadcrumbTitle)
                .IsRequired(false)
                .HasColumnOrder(102)
                .HasMaxLength(Constans.EntityConfigurationConstants.MaxStringLv6);

            builder.Property(x => x.SeoBreadcrumbTitle)
                .IsRequired(false)
                .HasColumnOrder(103)
                .HasMaxLength(Constans.EntityConfigurationConstants.MaxStringLv4);

            builder.Property(x => x.SeoDescription)
                .IsRequired(false)
                .HasColumnOrder(103)
                .HasMaxLength(Constans.EntityConfigurationConstants.MaxStringLv6);
        }

        protected void SitemapConfigure<T>(EntityTypeBuilder<T> builder) where T : class, IEntity, IEntitySitemap
        {
            builder.Property(x => x.sitemapNoIndex)
                .IsRequired(true)
                .HasDefaultValue<bool>(false);

            builder.Property(x => x.SitemapNoWrite)
                .IsRequired(true)
                .HasDefaultValue<bool>(false);

        }


        protected void UrlConfigure<T>(EntityTypeBuilder<T> builder) 
            where T : class, IEntity, IEntityUrl
        {
            builder.HasOne(x => x.Url)
                .WithMany()
                .HasForeignKey(x => x.UrlId)
                .OnDelete(DeleteBehavior.NoAction);
        }






    }
}
