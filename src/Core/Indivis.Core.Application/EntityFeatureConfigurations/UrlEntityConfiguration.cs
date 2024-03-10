using Indivis.Core.Application.Common.BaseClasses.EntityFeatureConfigurations;
using Indivis.Core.Application.Features.Systems.Queries.Urls;
using Indivis.Core.Domain.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.EntityFeatureConfigurations
{
    public class UrlEntityConfiguration : BaseEntityFeatureConfiguration<Url>
    {
        public UrlEntityConfiguration(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Entity()
                .SetMediatRGetByIdEntityQuery<GetByIdUrlQuery>();
        }

    }
}
