using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Common.SystemInitializers;
using Indivis.Core.Application.Interfaces.Features.Systems;
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

        public Type IGetByIdEntityQuery { get
            {
                return typeof(IGetByIdEntityQuery<>);
            } 
        }


        public Type CreateMapAttribute
        {
            get
            {
                return typeof(CreateMapAttribute);
            }
        }

    }
}
