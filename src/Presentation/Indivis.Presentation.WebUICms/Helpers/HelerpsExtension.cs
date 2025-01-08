using Indivis.Presentation.WebUICms.Common;
using Indivis.Presentation.WebUICms.Models.Helpers;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Indivis.Presentation.WebUICms.Helpers
{
	public static class HelerpsExtension
	{
        /*
		 
			<ul class="breadcrumb breadcrumb-separatorless fw-semibold fs-7 my-0 pt-1">
				<!--begin::Item-->
				<li class="breadcrumb-item text-muted">
					<a href="../../demo1/dist/index.html" class="text-muted text-hover-primary">Home</a>
				</li>
				<!--end::Item-->
				<!--begin::Item-->
				<li class="breadcrumb-item">
					<span class="bullet bg-gray-400 w-5px h-2px"></span>
				</li>
				<!--end::Item-->
				<!--begin::Item-->
				<li class="breadcrumb-item text-muted">Subscription</li>
				<!--end::Item-->
			</ul> 
		 
		 */



        public static IHtmlContent GetBreadcrumbs(this IHtmlHelper htmlHelper, string key)
		{
			IHtmlContentBuilder html = new HtmlContentBuilder();
			string li = "<li class=\"breadcrumb-item text-muted\">{0}</li>";

			KeyValuePair<string, CmsBreadcrumbModel> currentBreadcrumb = BaseCmsController.Breadcrumbs.First(x => x.Key == key);

			if (string.IsNullOrEmpty(currentBreadcrumb.Value.BaseKey))
			{

			}

			IEnumerable<KeyValuePair<string, CmsBreadcrumbModel>> result = CreateBreadcrumb(key, new Dictionary<string, CmsBreadcrumbModel>());

			foreach (KeyValuePair<string, CmsBreadcrumbModel> item in result)
			{
				if (result.Last().Value.Title == item.Value.Title)
				{
					html.AppendHtml(string.Format(li, item.Value.Title));
				}
				else
				{
					html.AppendHtml(string.Format(li, string.Format("<a href=\"{1}\" class=\"text-muted text-hover-primary\">{2}</a>", li, item.Value.Link, item.Value.Title)));
					html.AppendHtml(string.Format(li, "<span class=\"bullet bg-gray-400 w-5px h-2px\"></span>"));
				}

			}

			return html;
		}

		private static IEnumerable<KeyValuePair<string,CmsBreadcrumbModel>> CreateBreadcrumb(string key, Dictionary<string, CmsBreadcrumbModel> list)
		{
			KeyValuePair<string, CmsBreadcrumbModel> result = BaseCmsController.Breadcrumbs.First(x => x.Key == key);

			list.Add(result.Key, result.Value);

			if (!string.IsNullOrEmpty(result.Value.BaseKey))
			{
				CreateBreadcrumb(result.Value.BaseKey, list);
			}

			;
			return list.Reverse();
		}
	}
}
