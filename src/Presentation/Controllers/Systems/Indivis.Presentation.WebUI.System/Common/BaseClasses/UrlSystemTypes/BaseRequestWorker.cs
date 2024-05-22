using Indivis.Core.Application.Dtos.CoreEntityDtos.Pages.Reads;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;
using Indivis.Core.Application.Enums.Systems;
using Indivis.Core.Application.Exceptions.Systems;
using Indivis.Core.Application.Features.Systems.Queries.Pages;
using Indivis.Core.Application.Features.Systems.Queries.Widgets;
using Indivis.Core.Application.Features.Urls.Queries;
using Indivis.Core.Application.Interfaces.Data;
using Indivis.Core.Application.Interfaces.Data.Presentation;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Presentation.WebUI.System.Interfaces.Workers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUI.System.Common.BaseClasses.RequestWorkers
{
    public abstract class BaseUrlSystemTypes : IUrlSystemType
    {
        protected IMediator Mediator { get { return this.ServiceProvider.GetRequiredService<IMediator>(); } }
        protected IEntityFeatureContext EntityFeatureContext { get { return this.ServiceProvider.GetRequiredService<IEntityFeatureContext>(); } }
        protected ICurrentRequest CurrentRequest { get { return this.ServiceProvider.GetRequiredService<ICurrentRequest>(); } } 
        protected ICurrentResponse CurrentResponse { get { return this.ServiceProvider.GetRequiredService<ICurrentResponse>(); } }
        protected IServiceProvider ServiceProvider;
        public List<IUrlSystemType> UrlSystemTypes => new List<IUrlSystemType>();

        public BaseUrlSystemTypes(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        /// <summary>
        /// 1. CurrentUrlId değerine sahip sayfayı bulma
        /// </summary>
        /// <returns></returns>
        /// <exception cref="RequestNotFoundPageException"></exception>
        public virtual async Task ExecuteAsync()
        {

            IResultDataControl<ReadPageDto> getUrlIdResult = await this.GetByUrlIdPageAsync(this.CurrentRequest.CurrentUrl.Id);
            
            if (getUrlIdResult.IsSuccess)
            {
                this.CurrentResponse.CurrentPage = getUrlIdResult.Data;

                IResultDataControl<List<ReadPageZoneDto>> pageZones = await this.GetByPageIdZoneAsync(getUrlIdResult.Data.Id);

                if (pageZones.IsSuccess)
                {
                    this.CurrentResponse.CurrentPage.PageZones = pageZones.Data;
                }
            }
            else
            {
                throw new RequestNotFoundPageException(this.CurrentRequest.FullPath);
            }
        }

        /// <summary>
        /// UrlId değerine bağlı sayfayı döndürür.
        /// </summary>
        /// <param name="UrlId"></param>
        /// <returns></returns>
        public Task<IResultDataControl<ReadPageDto>> GetByUrlIdPageAsync(Guid urlId)
        {
            return this.Mediator.Send(this.EntityFeatureContext.CustomContext.GetDependencyMediatRQuery<GetByUrlIdPageQuery>(x =>
            {
                x.UrlId = urlId;
                x.State = StateEnum.Online;
            }));
        }

        public Task<IResultDataControl<List<ReadPageZoneDto>>> GetByPageIdZoneAsync(Guid pageId)
        {
            return this.Mediator.Send(new GetAllPageIdPageZonesQuery
            {
                PageId = pageId,
            });
        }
    }
}
