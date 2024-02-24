using Indivis.Core.Application.Interfaces.Data.Presentation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Indivis.Presentation.WebUI.System.Middlawares
{
    public class SystemRequestAboutMiddleware : IMiddleware
    {
        private readonly ICurrentRequest _currentRequest;

        public SystemRequestAboutMiddleware(ICurrentRequest currentRequest)
        {
            _currentRequest = currentRequest;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            ICurrentRequest request = context.RequestServices.GetRequiredService<ICurrentRequest>();    
            request.Domain = context.Request.Host.Value;
            request.Path = context.Request.Path;
            request.Schema = context.Request.Scheme;
            request.FullPath = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}";
            request.BaseUrl = $"{context.Request.Scheme}://{context.Request.Host}";

            List<string> workers = new List<string>
            {
                "EntityListWorker",
                "EntityDetailWorker",
                "PageWorker"
            };


            await next.Invoke(context);
        }
    }
}
