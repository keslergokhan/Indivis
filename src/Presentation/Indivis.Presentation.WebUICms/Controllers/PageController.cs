using Indivis.Core.Application.Dtos.CoreEntityDtos.PageSystems.Reads;
using Indivis.Core.Application.Enums.Systems;
using Indivis.Core.Application.Features.Pages.Queries;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Presentation.WebUICms.Common;
using Indivis.Presentation.WebUICms.Models.PageModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Indivis.Presentation.WebUICms.Controllers
{
    [Authorize(Roles = "BaseAdmin")]
    public class PageController : BaseController
    {

        public async Task<IActionResult> CreatePage()
        {
            ViewBag.Title = "Yeni bir sayfa oluştur";
            return View("~/Views/Page/CreatePageView.cshtml");
        }

        public async Task<IActionResult> PageSystems()
        {

            PageSystemViewOutModel model = new PageSystemViewOutModel();


            var aaaa = await base.Mediator.Send(base.EntityFeatureContext.PageSystems.GetMeditRGetAllEntityQuery(x=>x.Status = StateEnum.Online));

            IResultDataControl<List<ReadPageSystemDto>> resultPageSystems =
                await base.Mediator.Send(base.EntityFeatureCustomContext.GetDependencyMediatRQuery<GetPageSystemsQuery>(x => x.Status = Core.Application.Enums.Systems.StateEnum.Online));



            ViewBag.Title = "Sayfa Sistemleri";
            return View("~/Views/Page/PageSystemsView.cshtml");
        }
    }
}
