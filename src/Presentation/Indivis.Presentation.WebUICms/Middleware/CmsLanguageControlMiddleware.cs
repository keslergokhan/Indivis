
using Indivis.Core.Application.Dtos.CoreEntityDtos.Language.Reads;
using Indivis.Core.Application.Exceptions.Systems;
using Indivis.Core.Application.Features.Systems.Queries.Languages;
using Indivis.Core.Application.Interfaces.Results;
using MediatR;

namespace Indivis.Presentation.WebUICms.Middleware
{
    public class CmsLanguageControlMiddleware : IMiddleware
    {
        private readonly IMediator _mediator;

        public CmsLanguageControlMiddleware(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            ReadLanguageDto language = null;
            if (context.Request.Query.ContainsKey("cms_language"))
            {
                context.Request.Cookies.FirstOrDefault(x=>x.Key == )
            }
            else
            {
                IResultDataControl<ReadLanguageDto> resultDefaultLanguage = await this._mediator.Send(new GetDefaultLanguageSystemQuery());

                if (resultDefaultLanguage.IsSuccess)
                {
                    language = resultDefaultLanguage.Data;
                }
            }

            if (language == null)
            {
                throw new LanguageNotFaundException();
            }
            



            await next(context);   
        }
    }
}
