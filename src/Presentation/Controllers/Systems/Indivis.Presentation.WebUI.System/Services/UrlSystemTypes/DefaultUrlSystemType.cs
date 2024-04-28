using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Pages.Reads;
using Indivis.Core.Application.Exceptions.Systems;
using Indivis.Core.Application.Interfaces.Data.Presentation;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Application.Interfaces.UrlSystemTypes;
using Indivis.Presentation.WebUI.System.Common.BaseClasses.RequestWorkers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUI.System.Services.UrlSystemTypes
{
    //[DependencyRegister(typeof(IEntityListUrlSystemType), DependencyTypes.Singleton)]
    public class DefaultUrlSystemType : BaseUrlSystemTypes, IEntityDetailUrlSystemType
	{
        public DefaultUrlSystemType(IServiceProvider serviceProvider):base(serviceProvider)
        {
            
        }

		public override async Task ExecuteAsync()
		{
            await base.ExecuteAsync();
		}
	}
}
