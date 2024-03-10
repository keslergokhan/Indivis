using AutoMapper.Execution;
using Indivis.Core.Application.Common.BaseClasses.Features.Queries;
using Indivis.Core.Application.Features.Systems.Queries;
using Indivis.Core.Application.Interfaces.Features.FeatureFactories;
using Indivis.Core.Application.Interfaces.Features.Systems;
using Indivis.Core.Domain.Entities.CoreEntities;
using Indivis.Core.Domain.Interfaces.Entities.CoreEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Common.BaseClasses.EntityFeatureConfigurations
{
    public class EntityFeature
    {
        private IServiceProvider _serverProvider;

		public EntityFeature(IServiceProvider serverProvider)
		{
			_serverProvider = serverProvider;
		}

        public Type EntityType { get; set; }
        public BaseGetByIdEntityDataQuery MediatRGeyByIdEntityQuery { get; set; }


        public BaseGetByIdEntityDataQuery GetMediatRByIdEntityQuery(Action<BaseGetByIdEntityDataQuery> action)
        {
            action.Invoke(MediatRGeyByIdEntityQuery);
            return MediatRGeyByIdEntityQuery;
        }

        public TQuery GetDependencyMediatRQuery<TQuery>(Action<TQuery> action)
		where TQuery : class, IBaseRequest, IFeatureQueryFactory<TQuery>, new()
		{
            TQuery tQuery = (TQuery)this._serverProvider.GetService(typeof(TQuery));
            action.Invoke(tQuery);

            return tQuery;
		}
    }

    public abstract class BaseEntityFeatureConfiguration<TEntity> where TEntity : class, IEntity
    {
        private EntityFeature _entityFeature;

        public EntityFeature Features => _entityFeature;
        private IServiceProvider _serviceProvider;

        public BaseEntityFeatureConfiguration(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            this._entityFeature = new EntityFeature(serviceProvider);
        }
        public EntityFeatureBuilder<TEntity> Entity()
        {
            _entityFeature.EntityType = typeof(TEntity);
            return new EntityFeatureBuilder<TEntity>(_entityFeature, _serviceProvider);
        }
    }

    public class EntityFeatureBuilder<TEntity> where TEntity : class, IEntity
    {
        private EntityFeature _features;
        private IServiceProvider _serviceProvider;
        public EntityFeatureBuilder(EntityFeature features, IServiceProvider serviceProvider)
        {
            _features = features;
            _serviceProvider = serviceProvider;
        }

        public EntityFeatureBuilder<TEntity> SetMediatRGetByIdEntityQuery<TQuery>()
            where TQuery : class, IGetByIdEntityQuery<TEntity>, new()
        {
            _features.MediatRGeyByIdEntityQuery = (BaseGetByIdEntityDataQuery)_serviceProvider.GetService(typeof(IGetByIdEntityQuery<TEntity>));
            return this;
        }


        
    }


}
