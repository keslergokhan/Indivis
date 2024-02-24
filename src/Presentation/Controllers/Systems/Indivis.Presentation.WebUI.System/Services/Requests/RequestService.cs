using Indivis.Core.Application.Dtos.CoreEntityDtos.Urls.Reads;
using Indivis.Core.Application.Interfaces.Data;
using Indivis.Core.Application.Interfaces.Data.Presentation;
using Indivis.Presentation.WebUI.System.Interfaces.Services.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUI.System.Services.Requests
{
    public class RequestService : IRequestService
    {
        private readonly IMediator _mediator;
        private readonly IEntityFeatureContext _entityFeatureContext;

        public RequestService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ReadUrlDto> GetRequestUrlAsync(ICurrentRequest currentRequest)
        {
            throw new NotImplementedException();
        }

        public bool UrlSecurityVerification(ICurrentRequest currentRequest)
        {
            throw new NotImplementedException();
        }
    }
}
