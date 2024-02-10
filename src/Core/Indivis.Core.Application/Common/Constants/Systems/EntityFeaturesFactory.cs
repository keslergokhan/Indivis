using Indivis.Core.Application.Common.SystemInitializers.EntityFeatureConfigurations;
using Indivis.Core.Domain.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Common.Constants.Systems
{
    public static class EntityFeaturesContext
    {
        public static EntityFeatureConfiguration<Page> Page { get; set; }
    }
}
