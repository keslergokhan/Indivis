using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Common.BaseClasses.EntityFeatureConfigurations;
using Indivis.Core.Application.EntityFeatureConfigurations;
using Indivis.Core.Application.Interfaces.Data;
using Indivis.Core.Domain.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Common.Data
{
    [DependencyRegister(typeof(IEntityFeatureContext),DependencyTypes.Scopet)]
    public class EntityFeatureContext : BaseEntityFeatureContext, IEntityFeatureContext
    {
        private IServiceProvider _serviceProvider;

        public EntityFeatureContext(IServiceProvider serviceProvider):base(serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }


        public EntityFeature Page => SetConfigure<Page, PageEntityConfiguration>();

        public EntityFeature Url => SetConfigure<Url, UrlEntityConfiguration>();

        public EntityFeature EntityUrl => SetConfigure<EntityUrl, EntityUrlConfiguration>();




        public EntityFeature GetByNameEntityFeature(string entityName)
        {
            EntityFeature feature = base.EntityFeatures.GetValueOrDefault(entityName);
            if(feature is null)
            {
                PropertyInfo propertyInfo = this.GetType().GetProperty(entityName);
                if (propertyInfo != null)
                {
                    return (EntityFeature)propertyInfo.GetValue(this);
                }
                throw new Exception($"{entityName} bulunamadı !");
            }
            return feature;
        }
    }
}
