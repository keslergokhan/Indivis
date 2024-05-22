using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Pages.Reads;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;
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
            if (this.CurrentRequest.CurrentUrl.ParentUrlId == null || this.CurrentRequest.CurrentUrl.ParentUrlId == default)
            {
                throw new ParentUrlIdNotFoundException(this);
            }

            IResultDataControl<ReadPageDto> getUrlIdResult = await this.GetByUrlIdPageAsync(this.CurrentRequest.CurrentUrl.ParentUrlId);

            if (getUrlIdResult.IsSuccess)
            {
                
                this.CurrentResponse.CurrentPage = getUrlIdResult.Data;
                //this.CurrentRequest.CurrentEntityUrl = base.EntityFeatureContext.EntityUrl.GetMediatRByIdEntityQuery(x => x.Id = getUrlIdResult.Data.Id);

                IResultDataControl<List<ReadPageZoneDto>> pageZones = await this.GetByPageIdZoneAsync(this.CurrentRequest.CurrentUrl.ParentUrlId);

                if (pageZones.IsSuccess)
                {
                    this.CurrentResponse.CurrentPage.PageZones = pageZones?.Data;
                }
            }
            else
            {
                throw new RequestNotFoundPageException(this.CurrentRequest.FullPath);
            }
        }
    }
}
