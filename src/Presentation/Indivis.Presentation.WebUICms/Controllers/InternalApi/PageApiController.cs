using Indivis.Core.Application.Dtos.CoreEntityDtos.Pages.Writes;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Urls.Writes;
using Indivis.Core.Application.Features.Pages.Commands;
using Indivis.Core.Application.Features.Urls.Queries;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Application.Results;
using Indivis.Presentation.WebUICms.Common;
using Indivis.Presentation.WebUICms.Helpers;
using Indivis.Presentation.WebUICms.Models.InternalApiModels.PageModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Indivis.Presentation.WebUICms.Controllers.InternalApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageApiController : BaseApiController
    {


        [HttpPost]
        [Route("create-page")]
        public async Task<IActionResult> CreatePage([FromBody] CreatePageReqModel inModel)
        {

            WritePageDto page = new WritePageDto()
            {
                Name = inModel.Name,
                ParentPageId = inModel.ParentPageId == Guid.Empty ? null : inModel.ParentPageId,
                LanguageId = HttpContext.GetCurrentLanguageId(),
                PageSystemId = inModel.PageSystemId,
                Url = new WriteUrlDto()
                {
                    FullPath = inModel.FullPath,
                    ParentUrlId = inModel.ParentUrlId == Guid.Empty ? null : inModel.ParentUrlId,
                    Path = inModel.Path,
                    UrlSystemTypeId = inModel.UrlSystemTypeId,
                    LanguageId = HttpContext.GetCurrentLanguageId()
                }
            };



            await this.Mediator.Send(new AddPageCommand()
            {
                Page = page
            });


            return Ok(page);
        }


        /// <summary>
        /// FullPath adresinin mevcutta kullanılıp kullanılmadığını kontrol eder.
        /// </summary>
        /// <param name="inModel"></param>
        /// <returns>
        ///     Kontrol edilen url varsa true, yoksa false olarak dönüş yapar.
        /// </returns>
        [HttpPost]
        [Route("check-url-full-path")]
        public async Task<IActionResult> GetUrlControl([FromBody] GetUrlControlReqModel inModel)
        {
            IResultControl model = new ResultControl();

            IResultDataControl<CheckUrlFullPathQueryResult> checkUrlResult = await base.Mediator.Send(new CheckUrlFullPathQuery
            {
                FullPath = inModel.FullPath
            });

            return Ok(checkUrlResult);
        }
    }
}
