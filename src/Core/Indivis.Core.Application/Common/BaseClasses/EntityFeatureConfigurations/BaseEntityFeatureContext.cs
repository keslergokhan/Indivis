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

        protected Dictionary<string, EntityFeature> EntityFeatures = new Dictionary<string, EntityFeature>();

        public BaseEntityFeatureContext(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public EntityFeature SetConfigure<TEntity,TConfigure>() 
            where TEntity : class,IEntity
            where TConfigure : BaseEntityFeatureConfiguration<TEntity>
        {

            if(!this.EntityFeatures.Any(x=>x.Key == typeof(TEntity).Name))
            {
                BaseEntityFeatureConfiguration<TEntity> entityFeatureConfiguration = (BaseEntityFeatureConfiguration<TEntity>)this._serviceProvider.GetService(typeof(TConfigure));
                this.EntityFeatures.Add(typeof(TEntity).Name, entityFeatureConfiguration.Features);
                return entityFeatureConfiguration.Features;
            }
            else
            {
                return this.EntityFeatures.FirstOrDefault(x => x.Key == typeof(TEntity).Name).Value;
            }
            
        }
    }
}
