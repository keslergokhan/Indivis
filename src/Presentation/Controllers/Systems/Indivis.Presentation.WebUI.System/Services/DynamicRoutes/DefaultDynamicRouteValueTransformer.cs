using Indivis.Core.Application.Interfaces.Data.Presentation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUI.System.Services.DynamicRoutes
{
	public class DefaultDynamicRouteValueTransformer : DynamicRouteValueTransformer
	{
		private ICurrentRequest _currentRequest;
		private ICurrentResponse _currentResponse;

		public DefaultDynamicRouteValueTransformer(ICurrentRequest currentRequest, ICurrentResponse currentResponse)
		{
			_currentRequest = currentRequest;
			_currentResponse = currentResponse;
		}

		public override async ValueTask<RouteValueDictionary> TransformAsync(HttpContext httpContext, RouteValueDictionary values)
		{
			return values;
		}
	}
}
