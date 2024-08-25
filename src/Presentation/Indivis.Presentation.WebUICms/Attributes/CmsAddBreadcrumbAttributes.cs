using Indivis.Presentation.WebUICms.Common;
using Indivis.Presentation.WebUICms.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Indivis.Presentation.WebUICms.Attributes
{
	public class CmsAddBreadcrumbAttributes : ActionFilterAttribute
	{
		private string _key;
		private string _title;
		/// <summary>
		/// Cms dinamik route yapısı tanımlanmasını sağlar
		/// </summary>
		/// <param name="key">Key değeri nameof() ile tanımlanması tavsiye edilir </param>
		/// <param name="title">Breadcrumb yapısında link başlığı</param>
		/// <param name="link">Breadcrumb yapısında link adresi</param>
		/// <param name="clear">Breadcrumb listesini sil, controller tanımlamalarında kullanılması tavsiye edilir</param>
		public CmsAddBreadcrumbAttributes(string key,string title,string link,string baseKey=nameof(HomeCmsController))
        {
			_key = key;
			_title = title;

			if (!BaseCmsController.Breadcrumbs.Any(x=>x.Key == key))
			{
				BaseCmsController.Breadcrumbs.Add(key,new Models.Helpers.CmsBreadcrumbModel() { Title = title,Link = link,BaseKey = baseKey});
			}
        }
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			if(!string.IsNullOrEmpty(_key) && !string.IsNullOrEmpty(_title))
			{
				var controller = context.Controller as Controller;
				if (controller != null)
				{
					controller.ViewBag.Title = _title;
					controller.ViewBag.BreadcrumbKey = _key;
				}
				base.OnActionExecuting(context);
			}
			
		}




	}
}
