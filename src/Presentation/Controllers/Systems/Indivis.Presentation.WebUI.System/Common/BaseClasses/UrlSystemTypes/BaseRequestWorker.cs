using Indivis.Core.Application.Dtos.CoreEntityDtos.Pages.Reads;
using Indivis.Core.Application.Enums.Systems;
using Indivis.Core.Application.Features.Systems.Queries.Pages;
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
        protected IApplicationDbContext ApplicationDbContext { get { return this.ServiceProvider.GetRequiredService<IApplicationDbContext>(); } } 
        protected ICurrentRequest CurrentRequest { get { return this.ServiceProvider.GetRequiredService<ICurrentRequest>(); } } 
        protected ICurrentResponse CurrentResponse { get { return this.ServiceProvider.GetRequiredService<ICurrentResponse>(); } }
        protected IServiceProvider ServiceProvider;
        public List<IUrlSystemType> UrlSystemTypes => new List<IUrlSystemType>();

        public BaseUrlSystemTypes(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public abstract Task ExecuteAsync();

        public Task<IResultDataControl<ReadPageDto>> GetByUrlIdPageAsync(Guid UrlId)
        {
            return this.Mediator.Send(this.EntityFeatureContext.Url.GetDependencyMediatRQuery<GetByUrlIdPageQuery>(x =>
            {
                x.UrlId = UrlId;
                x.State = StateEnum.Online;
            }));
        }
    }
}
