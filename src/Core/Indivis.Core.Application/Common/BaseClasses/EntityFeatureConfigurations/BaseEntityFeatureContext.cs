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

        protected static Dictionary<string, EntityFeature> _EntityFeatures = new Dictionary<string, EntityFeature>();

        public static IReadOnlyDictionary<string, EntityFeature> EntityFeatures => _EntityFeatures;

        public BaseEntityFeatureContext(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public EntityFeature SetConfigure<TEntity,TConfigure>() 
            where TEntity : class,IEntity
            where TConfigure : BaseEntityFeatureConfiguration<TEntity>
        {

            if(!BaseEntityFeatureContext._EntityFeatures.Any(x=>x.Key == typeof(TEntity).Name))
            {
                BaseEntityFeatureConfiguration<TEntity> entityFeatureConfiguration = (BaseEntityFeatureConfiguration<TEntity>)this._serviceProvider.GetService(typeof(TConfigure));
                BaseEntityFeatureContext._EntityFeatures.Add(typeof(TEntity).Name, entityFeatureConfiguration.Features);
                return entityFeatureConfiguration.Features;
            }
            else
            {
                return BaseEntityFeatureContext._EntityFeatures.FirstOrDefault(x => x.Key == typeof(TEntity).Name).Value;
            }
            
        }
    }
}
