using Indivis.Core.Application.Common.SystemInitializers.EntityFeatureConfigurations;
using Indivis.Core.Application.Features.Systems.Queries;
using Indivis.Core.Domain.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Common.Data.EntityFeatureConfigurations
{
    public class PageEntityConfiguration : EntityFeatureConfiguration<Page>
    {
        public PageEntityConfiguration(IServiceProvider serviceProvider):base(serviceProvider)
        {
            Entity()
                .SetEntityDefaultProperty(x => x.Name)
                .SetMediatRGetByIdEntityQuery<GetByIdPageQuery>();
        }
    }
}
