using Indivis.Core.Application.Interfaces.Data.Presentation;
using Indivis.Presentation.WebUI.System.Interfaces.Services.Requests;
using Microsoft.AspNetCore.Http;

namespace Indivis.Presentation.WebUI.System.Middlewares
{
    public class SystemRequestAboutMiddleware : IMiddleware
    {

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            
           await next(context);
        }
    }

    
}
