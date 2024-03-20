using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Interfaces.Data.Presentation;
using Indivis.Core.Application.Interfaces.UrlSystemTypes;
using Indivis.Presentation.WebUI.System.Common.BaseClasses.RequestWorkers;
using Indivis.Presentation.WebUI.System.Interfaces.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUI.System.Services.UrlSystemTypes
{
    [DependencyRegister(typeof(IEntityListUrlSystemType),DependencyTypes.Transient)]
    public class EntityListUrlSystemType : BaseUrlSystemTypes, IEntityListUrlSystemType
    {
        public EntityListUrlSystemType(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            
        }
        public override async Task ExecuteAsync()
        {
            var sss = await this.GetByUrlIdPageAsync(Guid.Parse("84AF1EF5-73F6-4C4E-84AB-43DFAD02C755"));
            string sssafa = "";
        }
    }
}
