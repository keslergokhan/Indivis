using Indivis.Core.Application.Dtos.CoreEntityDtos.PageSystems.Reads;
using Indivis.Core.Application.Enums.Systems;
using Indivis.Core.Application.Features.Pages.Queries;
using Indivis.Core.Application.Features.Systems.Queries.Pages;
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
            var sss3 = base.EntityFeatureCustomContext.GetByNameEntityFeature("PageSystems").MediatRGetAllEntityDataQuery;

            sss3.OnlineAndOffline = true;
            sss3.Status = StateEnum.Online;

            var xxx = await base.Mediator.Send(sss3);

            IResultDataControl<object> sdf = (IResultDataControl<object>)xxx;

            var sss = base.EntityFeatureCustomContext.GetDependencyMediatRQuery<GetAllPageSystemsQuery>(x=>x.OnlineAndOffline = true);


            GetAllPageSystemsQuery pageSystemsGetAllQuery = (GetAllPageSystemsQuery)base.EntityFeatureContext.PageSystems.GetMeditRGetAllEntityQuery(x => x.OnlineAndOffline = true);

            var resultPageSystems = await base.Mediator.Send(pageSystemsGetAllQuery);



            ViewBag.Title = "Sayfa Sistemleri";
            return View("~/Views/Page/PageSystemsView.cshtml");
        }
    }
}
