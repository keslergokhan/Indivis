using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Common.BaseClasses.EntityFeatureConfigurations;
using Indivis.Core.Application.Common.BaseClasses.Features.Queries;
using Indivis.Core.Application.EntityFeatureConfigurations;
using Indivis.Core.Application.Interfaces.Data;
using Indivis.Core.Application.Interfaces.Features.FeatureFactories;
using Indivis.Core.Domain.Entities.CoreEntities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
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

        public EntityFeature PageSystems => SetConfigure<PageSystem, PageSystemsEntityConfiguration>();
    }

    [DependencyRegister(typeof(IEntityFeatureCustomContext), DependencyTypes.Scopet)]
    public class EntityFeatureCustomContext : IEntityFeatureCustomContext
    {
        private IServiceProvider _serviceProvider;

        public EntityFeatureCustomContext(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }


        public EntityFeature GetByNameEntityFeature(string entityName)
        {
            EntityFeature feature = BaseEntityFeatureContext.EntityFeatures.GetValueOrDefault(entityName);
            if (feature is null)
            {
                IEntityFeatureContext entityFeatureContextInstance = this._serviceProvider.GetService<IEntityFeatureContext>();
                PropertyInfo propertyInfo = entityFeatureContextInstance.GetType().GetProperty(entityName);
                if (propertyInfo != null)
                {
                    return (EntityFeature)propertyInfo.GetValue(entityFeatureContextInstance);
                }
                throw new Exception($"{entityName} bulunamadı !");
            }
            return feature;
        }

        public TQuery GetDependencyMediatRQuery<TQuery>(Action<TQuery> action)
        where TQuery : class, IBaseRequest, IQueryFactory<TQuery>, new()
        {
            TQuery tQuery = (TQuery)this._serviceProvider.GetService(typeof(TQuery));
            action.Invoke(tQuery);

            return tQuery;
        }
    }
}
