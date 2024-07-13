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
    //public class Url_UrlSystemTypeConfiguration : IEntityTypeConfiguration<Url_UrlSystemType>
    //{
    //    public void Configure(EntityTypeBuilder<Url_UrlSystemType> builder)
    //    {
    //        builder.ToTable(nameof(Url_UrlSystemType));
    //        builder.HasKey(sc => new { sc.UrlId, sc.UrlSystemTypeId });
    //        builder.HasOne(x => x.Url).WithMany(x => x.Url_UrlSystemTypes).HasForeignKey(x=>x.UrlId);
    //        builder.HasOne(x => x.UrlSystemType).WithMany(x => x.Url_UrlSystemTypes).HasForeignKey(x => x.UrlSystemTypeId);

    //    }
    //}
}
