using Indivis.Core.Application.Common.BaseClasses.EntityFeatureConfigurations;
using Indivis.Core.Domain.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Interfaces.Data
{
    public interface IEntityFeatureContext
    {
        public EntityFeature Page { get; }

        public EntityFeature GetByNameEntityFeature(string entityName);

    }
}
