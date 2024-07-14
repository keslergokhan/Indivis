using Indivis.Core.Application.Common.Constants.Systems;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Language.Reads;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Urls.Reads;
using Indivis.Core.Application.Helpers.Systems;
using Indivis.Core.Application.Interfaces.Data.Presentation;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Presentation.WebUI.System.Interfaces.Services.Requests;
using Indivis.Presentation.WebUI.System.Interfaces.Workers;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

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


        public void CreateLanguageCookie(HttpContext httpContext, ReadLanguageDto readLanguageDto)
        {
            httpContext.Response.Cookies.Append("language",JsonSerializer.Serialize(readLanguageDto));
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            string isExtension = Path.GetExtension(context.Request.Path);
            if (string.IsNullOrEmpty(isExtension))
            {
                this._currentRequest.Path = context.Request.Path;
                this._currentRequest.Schema = context.Request.Scheme;
                this._currentRequest.FullPath = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}";
                this._currentRequest.BaseUrl = $"{context.Request.Scheme}://{context.Request.Host}";

                IResultDataControl<ReadUrlDto> requestAboutResult = await this._requestService.GetRequestUrlAsync(this._currentRequest);


                

                if (requestAboutResult.IsSuccess)
                {
                    this.CreateLanguageCookie(context, requestAboutResult.Data.Language);
                    this._currentRequest.CurrentUrl = requestAboutResult.Data;
                    if (requestAboutResult.Data.UrlSystemType != null)
                    {
                        IUrlSystemType urlSystemType = SystemDependencyInjection.Instance.GetByNameApplicationInjectionType<IUrlSystemType>(context.RequestServices, requestAboutResult.Data.UrlSystemType.InterfaceType);
                        await urlSystemType.ExecuteAsync();
                    }
                    else
                    {
                        IUrlSystemType urlSystemType = SystemDependencyInjection.Instance.GetByNameApplicationInjectionType<IUrlSystemType>(context.RequestServices, SystemClassTypeConstant.Instance.IEntityDetailUrlSystemType.Name);
                        await urlSystemType.ExecuteAsync();
                    }

                }
            }
            
           await next(context);
        }
    }

    
}
