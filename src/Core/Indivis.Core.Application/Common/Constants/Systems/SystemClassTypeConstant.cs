using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Common.BaseClasses.EntityFeatureConfigurations;
using Indivis.Core.Application.Interfaces.Data;
using Indivis.Core.Application.Interfaces.Features.FeatureFactories;
using Indivis.Core.Application.Interfaces.UrlSystemTypes;
using Indivis.Core.Domain.Interfaces.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Common.Constants.Systems
{
    public class SystemClassTypeConstant
    {
        private static readonly Lazy<SystemClassTypeConstant>
            CreateInstance = new Lazy<SystemClassTypeConstant>(() =>
            {
                return new SystemClassTypeConstant();
            });

        public static SystemClassTypeConstant Instance
        {
            get
            {
                return SystemClassTypeConstant.CreateInstance.Value;
            }
        }

        private SystemClassTypeConstant()
        {
            
        }

        public Type IEntity
        {
            get { return typeof(IEntity); }
        }

        public Type DependenctyRegisterAttribute
        {
            get
            {
                return typeof(DependencyRegisterAttribute);
            }
        }

        public Type CreateMapAttribute
        {
            get
            {
                return typeof(CreateMapAttribute);
            }
        }

        public Type IEntityFeatureContext
        {
            get{
                return typeof(IEntityFeatureContext);
            }
        }

        public Type BaseEntityFeatureConfiguration
        {
            get
            {
                return typeof(BaseEntityFeatureConfiguration<>);
            }
        }

        public Type IFeatureQueryFactory
        {
            get
            {
                return typeof(IFeatureQueryFactory<>);
            }
        }

        public Type IEntityDetailUrlSystemType
        {
            get
            {
                return typeof(IEntityDetailUrlSystemType);
            }
        }


	}
}
