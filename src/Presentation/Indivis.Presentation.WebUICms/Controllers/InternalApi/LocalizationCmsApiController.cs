using AutoMapper;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Localization.Reads;
using Indivis.Core.Application.Enums.Systems;
using Indivis.Core.Application.Features.Systems.Commands.Localizations;
using Indivis.Core.Application.Features.Systems.Queries.Localizations;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Presentation.WebUICms.Helpers;
using Indivis.Presentation.WebUICms.Models.InternalApiModels.LocalizationModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Indivis.Presentation.WebUICms.Controllers.InternalApi
{
    [Route("api/[controller]")]
    [Authorize(Roles = "BaseAdmin")]
    [ApiController]
    public class LocalizationCmsApiController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocalizationCmsApiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("get-localization/{key}")]
        public async Task<IActionResult> GetLocalization(string key)
        {
            IResultDataControl<ReadLocalizationDto> localization = await this._mediator.Send(new GetByKeyLocalizationSystemQuery()
            {
                Key = key
            });
            return Ok(localization);
        }


        [HttpPost]
        [Route("update-localization")]
        public async Task<IActionResult> LocalizationUpdate([FromBody] UpdateLocalizationReqModel req)
        {
            IResultDataControl<ReadLocalizationDto> resultLocalizaiton = await this._mediator.Send(new AddLocalizationRegionSystemCommand()
            {
                LanguageId = HttpContext.GetCurrentLanguageId(),
                LocalizationRegion = new Core.Application.Dtos.CoreEntityDtos.Localization.Writes.WriteLocalizationRegionDto
                {
                    LanguageId = HttpContext.GetCurrentLanguageId(),
                    LocalizationId = req.Localization.LocalizationId,
                    Value = req.Localization.Value,
                    State = (int)StateEnum.Online
                    
                }
            });
            return Ok(resultLocalizaiton);
        }
    }
}
