
using Indivis.Core.Application.Dtos.CoreEntityDtos.Language.Reads;
using Indivis.Core.Application.Exceptions.Systems;
using Indivis.Core.Application.Features.Languages.Queries;
using Indivis.Core.Application.Features.Systems.Queries.Languages;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Presentation.WebUICms.Helpers;
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
            ReadLanguageDto language = context.CookieGetObject<ReadLanguageDto>(Helpers.CookieExtensions.LanguageKey);
            bool isNewLanguage = false;
            //querystring üzerinde language varsa
            if (context.Request.Query.ContainsKey(Helpers.CookieExtensions.LanguageKey))
            {
                var languageResult = context.Request.Query[Helpers.CookieExtensions.LanguageKey];

                Guid languageId;
                if (Guid.TryParse(languageResult, out languageId))
                {
                    IResultDataControl<ReadLanguageDto> resultLanguage = await this._mediator.Send(new GetByIdLanguageQuery()
                    {
                        Id = languageId,
                    });

                    if (resultLanguage.IsSuccess)
                    {
                        language = resultLanguage.Data;
                        isNewLanguage = true;
                    }
                }
                else
                {
                    throw new FormatException($"query üzerinde {Helpers.CookieExtensions.LanguageKey} değeri doğru format taşımıyor !");
                }

            }
            else if(language == null)
            {
                IResultDataControl<ReadLanguageDto> resultDefaultLanguage = await this._mediator.Send(new GetDefaultLanguageSystemQuery());

                if (resultDefaultLanguage.IsSuccess)
                {
                    language = resultDefaultLanguage.Data;
                    isNewLanguage = true;
                }
                
            }

            if (language == null)
            {
                throw new LanguageNotFaundException();
            }

            if (isNewLanguage)
            {
                context.CookieSetObject<ReadLanguageDto>(Helpers.CookieExtensions.LanguageKey, language);
            }
            

            await next(context);   
        }
    }
}
