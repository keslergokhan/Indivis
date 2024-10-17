using Indivis.Core.Application.Dtos.CoreEntityDtos.Language.Reads;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Localization.Reads;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Pages.Reads;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;
using Indivis.Core.Application.Enums.Systems;
using Indivis.Core.Application.Exceptions.Systems;
using Indivis.Core.Application.Features.Systems.Queries.Localizations;
using Indivis.Core.Application.Features.Systems.Queries.Pages;
using Indivis.Core.Application.Features.Systems.Queries.Widgets;
using Indivis.Core.Application.Interfaces.Data;
using Indivis.Core.Application.Interfaces.Data.Presentation;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Presentation.WebUI.System.Interfaces.Workers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Indivis.Presentation.WebUI.System.Common.BaseClasses.RequestWorkers
{
    public abstract class BaseUrlSystemTypes : IUrlSystemType
    {
        protected IMediator Mediator { get { return this.ServiceProvider.GetRequiredService<IMediator>(); } }
        protected IEntityFeatureContext EntityFeatureContext { get { return this.ServiceProvider.GetRequiredService<IEntityFeatureContext>(); } }
        protected IEntityFeatureCustomContext EntityFeatureCustomContext { get { return this.ServiceProvider.GetRequiredService<IEntityFeatureCustomContext>(); }
}
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
                IResultDataControl<List<ReadLocalizationDto>> localizations = await this.GetAllPageLocalizationAsync(getUrlIdResult.Data);

                if (pageZones.IsSuccess)
                {
                    this.CurrentResponse.CurrentPage.PageZones = pageZones.Data;
                }

                if (localizations.IsSuccess)
                {
                    this.CurrentResponse.CurrentPage.Localization = localizations.Data;
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
            return this.Mediator.Send(this.EntityFeatureCustomContext.GetDependencyMediatRQuery<GetPageByUrlIdSystemQuery>(x =>
            {
                x.UrlId = urlId;
                x.State = StateEnum.Online;
            }));
        }

        public Task<IResultDataControl<List<ReadLocalizationDto>>> GetAllPageLocalizationAsync(ReadPageDto page)
        {
            return this.Mediator.Send(new GetAllByPageIdLocalizationSystemQuery()
            {
                PageId = page.Id,
                LanguageId = page.LanguageId,
            });
        }

        public Task<IResultDataControl<List<ReadPageZoneDto>>> GetByPageIdZoneAsync(Guid pageId)
        {
            return this.Mediator.Send(new GetAllPageIdPageZonesSystemQuery
            {
                PageId = pageId,
            });
        }
    }
}
