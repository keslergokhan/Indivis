using Indivis.Core.Application.Dtos.CoreEntityDtos.PageSystems.Reads;
using Indivis.Core.Application.Enums.Systems;
using Indivis.Core.Application.Exceptions;
using Indivis.Core.Application.Features.Pages.Queries;
using Indivis.Core.Application.Features.Systems.Queries.Pages;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Application.Results;
using Indivis.Presentation.WebUICms.Common;
using Indivis.Presentation.WebUICms.Models.PageModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Indivis.Presentation.WebUICms.Controllers
{
    [Authorize(Roles = "BaseAdmin")]
    [Route("[controller]")]
    public class PageController : BaseController
    {
        [Route("createpage/{Id:guid}")]
        public async Task<IActionResult> CreatePage(Guid Id)
        {
            CreatePageViewOutModel model = new CreatePageViewOutModel();

            var query = base.EntityFeatureCustomContext.GetDependencyMediatRQuery<GetPageSystemByIdQuery>(x=>x.Id = Id);

            IResultDataControl<ReadPageSystemDto> result = await this.Mediator.Send(query);
            if (!result.IsSuccess)
            {
                throw new ViewDataNotFoundException(nameof(ReadPageSystemDto));
            }

            model.PageSystem = result.Data;

            ViewBag.Title = "Yeni bir sayfa oluştur";
            return View("~/Views/Page/CreatePageView.cshtml",model);
        }

        [Route("pagesystems")]
        public async Task<IActionResult> PageSystems()
        {
            PageSystemViewOutModel model = new PageSystemViewOutModel();

            IResultDataControl<List<ReadPageSystemDto>> resultPageSystems = await base.Mediator.Send(base.EntityFeatureCustomContext.GetDependencyMediatRQuery<GetPageSystemsAndPageQuery>(x=>x.OnlineAndOffline = true));

            if (!resultPageSystems.IsSuccess)
            {
                throw new ViewDataNotFoundException(nameof(ReadPageSystemDto));
            }

            model.PageSystems = resultPageSystems.Data;

            ViewBag.Title = "Sayfa Sistemleri";
            return View("~/Views/Page/PageSystemsView.cshtml",model);
        }

      
    }
}
