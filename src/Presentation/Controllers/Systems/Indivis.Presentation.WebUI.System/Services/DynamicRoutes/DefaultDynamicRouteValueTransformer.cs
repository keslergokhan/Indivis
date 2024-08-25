using Indivis.Core.Application.Common.Constants.Systems;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Language.Reads;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Urls.Reads;
using Indivis.Core.Application.Helpers.Systems;
using Indivis.Core.Application.Interfaces.Data.Presentation;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Presentation.WebUI.System.Constants;
using Indivis.Presentation.WebUI.System.Interfaces.Services.Requests;
using Indivis.Presentation.WebUI.System.Interfaces.Workers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUI.System.Services.DynamicRoutes
{
	public class DefaultDynamicRouteValueTransformer : DynamicRouteValueTransformer
	{
        
        private ICurrentRequest _currentRequest;
		private ICurrentResponse _currentResponse;
        private IRequestService _requestService;

        public DefaultDynamicRouteValueTransformer(ICurrentRequest currentRequest, ICurrentResponse currentResponse, IRequestService requestService)
        {
            _currentRequest = currentRequest;
            _currentResponse = currentResponse;
            _requestService = requestService;
        }

        public void CreateLanguageCookie(HttpContext httpContext, ReadLanguageDto readLanguageDto)
        {
            httpContext.Response.Cookies.Append("language", JsonSerializer.Serialize(readLanguageDto));
        }

        private async Task UrlSystemTypeInvokerAsync(HttpContext context)
        {
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

        public override async ValueTask<RouteValueDictionary> TransformAsync(HttpContext context, RouteValueDictionary values)
		{
            this._currentRequest.Path = context.Request.Path;
            this._currentRequest.Schema = context.Request.Scheme;
            this._currentRequest.Path = this._currentRequest.Path.Replace(WebUISystemContant.CmsPageEditRoute, "");
            this._currentRequest.FullPath = $"{context.Request.Scheme}://{context.Request.Host}{this._currentRequest.Path}";
            this._currentRequest.BaseUrl = $"{context.Request.Scheme}://{context.Request.Host}";

            await UrlSystemTypeInvokerAsync(context);


            if (this._currentResponse.CurrentPage != null)
			{
                values["controller"] = this._currentResponse.CurrentPage.PageSystem.Controller.Replace("Controller", "");
                values["action"] = this._currentResponse.CurrentPage.PageSystem.Action;
			}
			

			return values;
		}
	}
}
