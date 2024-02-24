using Indivis.Core.Application.Dtos.CoreEntityDtos.Urls.Reads;
using Indivis.Core.Application.Interfaces.Data.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUI.System.Interfaces.Services.Requests
{
    public interface IRequestService
    {
        public Task<ReadUrlDto> GetRequestUrlAsync(ICurrentRequest currentRequest);
        public bool UrlSecurityVerification(ICurrentRequest currentRequest);
    }
}
