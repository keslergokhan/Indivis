using Indivis.Core.Application.Interfaces.Data.Presentation;
using Indivis.Presentation.WebUI.System.Interfaces.Services.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Indivis.Presentation.WebUI.System.Middlawares
{
    public class SystemRequestAboutMiddleware : IMiddleware
    {
        private ICurrentRequest _currentRequest;
        private IRequestService _requestService;

        public SystemRequestAboutMiddleware(ICurrentRequest currentRequest, IRequestService requestService)
        {
            _currentRequest = currentRequest;
            _requestService = requestService;
        }




        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            
            this._currentRequest.Path = context.Request.Path;
            this._currentRequest.Schema = context.Request.Scheme;
            this._currentRequest.FullPath = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}";
            this._currentRequest.BaseUrl = $"{context.Request.Scheme}://{context.Request.Host}";

            
            var result = await this._requestService.GetRequestUrlAsync(this._currentRequest);


            await next.Invoke(context);
        }
    }
}
