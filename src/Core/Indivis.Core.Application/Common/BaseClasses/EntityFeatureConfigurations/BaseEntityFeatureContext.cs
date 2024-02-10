using Indivis.Core.Application.Common.SystemInitializers.EntityFeatureConfigurations;
using Indivis.Core.Domain.Interfaces.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Common.BaseClasses.EntityFeatureConfigurations
{
    public abstract class BaseEntityFeatureContext
    {
        private IServiceProvider _serviceProvider;

        protected Dictionary<string, EntityFeature> EntityFeatures = new Dictionary<string, SystemInitializers.EntityFeatureConfigurations.EntityFeature>();

        public BaseEntityFeatureContext(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public EntityFeatureConfiguration<TEntity> SetConfigure<TEntity,TConfigure>() 
            where TEntity : class,IEntity
            where TConfigure : EntityFeatureConfiguration<TEntity>
        {
            EntityFeatureConfiguration<TEntity> entityFeatureConfiguration = (EntityFeatureConfiguration<TEntity>)this._serviceProvider.GetService(typeof(TConfigure));
            this.EntityFeatures.Add(typeof(TEntity).Name, entityFeatureConfiguration.Features);
            return entityFeatureConfiguration;
        }
    }
}
