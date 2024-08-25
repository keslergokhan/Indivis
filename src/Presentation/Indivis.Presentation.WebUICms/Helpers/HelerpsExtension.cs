using Indivis.Presentation.WebUICms.Common;
using Indivis.Presentation.WebUICms.Models.Helpers;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Indivis.Presentation.WebUICms.Helpers
{
	public static class HelerpsExtension
	{

		public static IHtmlContent GetBreadcrumbs(this IHtmlHelper htmlHelper, string key)
		{
			IHtmlContentBuilder html = new HtmlContentBuilder();
			string li = "<li class=\"breadcrumb-item pe-3 \">{0}</li>";

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
					html.AppendHtml(string.Format(li, string.Format("<a href=\"{1}\" class=\"pe-3\">{2}</a>", li, item.Value.Link, item.Value.Title)));
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
