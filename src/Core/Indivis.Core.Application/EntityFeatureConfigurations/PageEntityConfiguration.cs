using Indivis.Core.Application.Common.BaseClasses.EntityFeatureConfigurations;
using Indivis.Core.Application.Features.Systems.Queries;
using Indivis.Core.Domain.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.EntityFeatureConfigurations
{
    public class PageEntityConfiguration : BaseEntityFeatureConfiguration<Page>
    {
        public PageEntityConfiguration(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Entity()
                .SetEntityDefaultProperty(x => x.Name)
                .SetMediatRGetByIdEntityQuery<GetByIdPageQuery>();
        }
    }
}
