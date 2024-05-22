using Indivis.Core.Application.Common.BaseClasses.EntityFeatureConfigurations;
using Indivis.Core.Application.Common.BaseClasses.Features.Queries;
using Indivis.Core.Application.Interfaces.Features.FeatureFactories;
using Indivis.Core.Domain.Entities.CoreEntities;
using MediatR;
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
        public EntityFeature Url { get; }
        public EntityFeature EntityUrl { get; }

        public IEntityFeatureCustomContext CustomContext {get;}


    }

    public interface IEntityFeatureCustomContext
    {
        public EntityFeature GetByNameEntityFeature(string entityName);

        public TQuery GetDependencyMediatRQuery<TQuery>(Action<TQuery> action) where TQuery : class, IBaseRequest, IFeatureQueryFactory<TQuery>, new ();
    }
}
