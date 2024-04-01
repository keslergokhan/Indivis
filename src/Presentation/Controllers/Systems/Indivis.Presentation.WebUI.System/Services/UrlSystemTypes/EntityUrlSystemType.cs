using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Pages.Reads;
using Indivis.Core.Application.Exceptions.Systems;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Application.Interfaces.UrlSystemTypes;
using Indivis.Core.Domain.Commons.CoreEntities;
using Indivis.Presentation.WebUI.System.Common.BaseClasses.RequestWorkers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUI.System.Services.UrlSystemTypes
{
    [DependencyRegister(typeof(IEntityUrlSystemType),DependencyTypes.Scopet)]
    public class EntityUrlSystemType : BaseUrlSystemTypes, IEntityUrlSystemType
    {
        public EntityUrlSystemType(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        public override async Task ExecuteAsync()
        {
            IResultDataControl<ReadPageDto> getUrlIdResult = await this.GetByUrlIdPageAsync(this.CurrentRequest.CurrentUrl.ParentUrlId);
            if (getUrlIdResult.IsSuccess)
            {
                this.CurrentResponse.CurrentPage = getUrlIdResult.Data;
            }
            else
            {
                throw new RequestNotFoundPageException(base.CurrentRequest.FullPath);
            }
        }
    }
}
