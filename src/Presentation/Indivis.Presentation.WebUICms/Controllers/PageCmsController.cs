using Indivis.Core.Application.Dtos.CoreEntityDtos.Pages.Reads;
using Indivis.Core.Application.Dtos.CoreEntityDtos.PageSystems.Reads;
using Indivis.Core.Application.Exceptions;
using Indivis.Core.Application.Features.Pages.Queries;
using Indivis.Core.Application.Features.Systems.Queries.Pages;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Presentation.WebUICms.Attributes;
using Indivis.Presentation.WebUICms.Common;
using Indivis.Presentation.WebUICms.Models.PageModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Indivis.Presentation.WebUICms.Controllers
{
    [Authorize(Roles = "BaseAdmin")]
    [Route("[controller]")]
    [CmsAddBreadcrumbAttributes(nameof(PageCmsController),"Sayfa","/pagecms/pagesystems")]
    public class PageCmsController : BaseController
    {
        public PageCmsController()
        {
        }


        [Route("createpage/{pageSystemId:guid}")]
        [Route("createpage/{pageSystemId:guid}/{parentPageId:guid}")]
		[CmsAddBreadcrumbAttributes(nameof(PageCmsController.CreatePage), "Yeni Sayfa Ekle", "",nameof(PageCmsController.PageSystems))]
		public async Task<IActionResult> CreatePage(Guid pageSystemId,Guid parentPageId)
        {

			CreatePageViewOutModel model = new CreatePageViewOutModel();


            IResultDataControl<ReadPageSystemDto> result = await this.Mediator.Send(new GetPageSystemByIdQuery
            {
                Id = pageSystemId,
            });

            if (!result.IsSuccess)
            {
                throw new ViewDataNotFoundException(nameof(ReadPageSystemDto));
            }

            if (parentPageId != Guid.Empty)
            {
                IResultDataControl<ReadPageDto> resultPage = await this.Mediator.Send(new GetPageByIdQuery(){
                    Id = parentPageId,
                });

                if (!resultPage.IsSuccess)
                {
                    throw new ViewDataNotFoundException(nameof(ReadPageDto));
                }

                model.ParentPage = resultPage.Data;
            }

            model.PageSystem = result.Data;

            
			return View("~/Views/Page/CreatePageView.cshtml",model);
        }

        [Route("pagesystems")]
		[CmsAddBreadcrumbAttributes(nameof(PageCmsController.PageSystems), "Sayfa Sistemleri", "/pagecms/pagesystems", nameof(PageCmsController))]
		public async Task<IActionResult> PageSystems()
        {

			PageSystemViewOutModel model = new PageSystemViewOutModel();

            IResultDataControl<List<ReadPageSystemDto>> resultPageSystems = await base.Mediator.Send(new GetPageSystemsAndPageQuery
            {
                OnlineAndOffline = true,
            });

            if (!resultPageSystems.IsSuccess)
            {
                throw new ViewDataNotFoundException(nameof(ReadPageSystemDto));
            }

            model.PageSystems = resultPageSystems.Data;

            
            return View("~/Views/Page/PageSystemsView.cshtml",model);
        }

      
    }
}
