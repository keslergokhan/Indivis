using Indivis.Core.Application.Common.BaseClasses.EntityFeatureConfigurations;
using Indivis.Core.Application.Features.Systems.Queries.EntityUrls;
using Indivis.Core.Domain.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.EntityFeatureConfigurations
{
    public class EntityUrlConfiguration : BaseEntityFeatureConfiguration<EntityUrl>
    {
        public EntityUrlConfiguration(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Entity()
                .SetMediatRGetByIdEntityQuery<GetByIdEntityUrlQuery>();
        }
    }
}
