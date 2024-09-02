using Indivis.Core.Application.Dtos.CoreEntityDtos.Urls.Reads;
using Indivis.Core.Application.Interfaces.Data.Presentation;
using Indivis.Core.Application.Interfaces.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUI.System.Interfaces.Services.Requests
{
    public interface IRequestService
    {
        public Task<IResultDataControl<ReadUrlDto>> GetRequestUrlAsync(ICurrentRequest currentRequest);
        public bool UrlSecurityVerification(ICurrentRequest currentRequest);
    }
}
