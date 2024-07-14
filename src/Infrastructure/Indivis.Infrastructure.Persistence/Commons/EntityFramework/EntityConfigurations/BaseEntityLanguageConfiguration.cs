using Indivis.Core.Domain.Entities.CoreEntities;
using Indivis.Core.Domain.Interfaces.Entities.CoreEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Infrastructure.Persistence.Commons.EntityFramework.EntityConfigurations
{
    public abstract class BaseEntityLanguageConfiguration<T> : BaseEntityConfiguration<T> where T:class,IEntityLanguage
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);
            builder.HasOne<Language>().WithMany().HasForeignKey(x => x.LanguageId);
        }
    }

    public abstract class BaseEntityLanguageProConfiguration<T> : BaseEntityConfiguration<T> where T : class, IEntityLanguagePro
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);
            builder.HasOne(x=>x.Language).WithMany().HasForeignKey(x => x.LanguageId);
        }
    }
}
