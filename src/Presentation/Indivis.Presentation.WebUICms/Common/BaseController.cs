using Indivis.Core.Application.Interfaces.Data;
using Indivis.Presentation.WebUICms.Controllers;
using Indivis.Presentation.WebUICms.Models.Helpers;
using MediatR;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace Indivis.Presentation.WebUICms.Common
{
    public abstract class BaseController : Controller
    {
        public static Dictionary<string, CmsBreadcrumbModel> Breadcrumbs = new Dictionary<string, CmsBreadcrumbModel>();

        public virtual IMediator Mediator { get { return HttpContext.RequestServices.GetService<IMediator>(); } }
        public virtual IEntityFeatureContext EntityFeatureContext { get { return HttpContext.RequestServices.GetService<IEntityFeatureContext>(); ; } }
        public virtual IEntityFeatureCustomContext EntityFeatureCustomContext { get { return HttpContext.RequestServices.GetService<IEntityFeatureCustomContext>(); } }


        public BaseController ClearBreadcrumbs()
        {
			BaseController.Breadcrumbs.Clear();
            return this;
        }

  
    }
}
