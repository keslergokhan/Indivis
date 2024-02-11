using AutoMapper.Execution;
using Indivis.Core.Application.Common.BaseClasses.Features.Queries;
using Indivis.Core.Application.Features.Systems.Queries;
using Indivis.Core.Application.Interfaces.Features.Systems;
using Indivis.Core.Domain.Entities.CoreEntities;
using Indivis.Core.Domain.Interfaces.Entities.CoreEntities;
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
        public Type EntityType { get; set; }
        public PropertyInfo EntityDefaultPropertyType { get; set; }
        public BaseGetByIdEntityDataQuery MediatRGeyByIdEntityQuery { get; set; }


        public BaseGetByIdEntityDataQuery SetMediatRByIdEntityQuery(Action<BaseGetByIdEntityDataQuery> action)
        {
            action.Invoke(MediatRGeyByIdEntityQuery);
            return MediatRGeyByIdEntityQuery;
        }
    }

    public abstract class BaseEntityFeatureConfiguration<TEntity> where TEntity : class, IEntity
    {
        private EntityFeature _entityFeature = new EntityFeature();

        public EntityFeature Features => _entityFeature;
        private IServiceProvider _serviceProvider;

        public BaseEntityFeatureConfiguration(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
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


        public EntityFeatureBuilder<TEntity> SetEntityDefaultProperty<TResult>(Expression<Func<TEntity, TResult>> expression) where TResult : class
        {
            string member = expression.GetMember().Name;
            _features.EntityDefaultPropertyType = _features.EntityType.GetProperty(member);
            return this;
        }

        public EntityFeatureBuilder<TEntity> SetMediatRGetByIdEntityQuery<TQuery>()
            where TQuery : class, IGetByIdEntityQuery<TEntity>, new()
        {
            _features.MediatRGeyByIdEntityQuery = (BaseGetByIdEntityDataQuery)_serviceProvider.GetService(typeof(IGetByIdEntityQuery<TEntity>));
            return this;
        }
    }


}
