using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Urls.Reads;
using Indivis.Core.Application.Features.Urls.Queries;
using Indivis.Core.Application.Interfaces.Data;
using Indivis.Core.Application.Interfaces.Data.Presentation;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Presentation.WebUI.System.Interfaces.Services.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUI.System.Services.Requests
{
    [DependencyRegister(typeof(IRequestService),DependencyTypes.Scopet)]
    public class RequestService : IRequestService
    {
        private readonly IMediator _mediator;
        private readonly IEntityFeatureContext _entityFeatureContext;

        public RequestService(IMediator mediator, IEntityFeatureContext entityFeatureContext)
        {
            _mediator = mediator;
            _entityFeatureContext = entityFeatureContext;
        }

        public Task<IResultDataControl<ReadUrlDto>> GetRequestUrlAsync(ICurrentRequest currentRequest)
        {
            return this._mediator.Send(this._entityFeatureContext.Url.GetDependencyMediatRQuery<GetByFullPathUrlQuery>(x => x.FullPath = currentRequest.Path));
        }

        public bool UrlSecurityVerification(ICurrentRequest currentRequest)
        {
            throw new NotImplementedException();
        }
    }
}
