using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;
using Indivis.Core.Application.Interfaces.Data.Presentation;
using Indivis.Presentation.WebUI.Widgets.Models.ViewComponents;
using Indivis.Presentation.WebUI.Widgets.ViewComponents.Widgets;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Encodings.Web;

namespace Indivis.Presentation.WebUI.Widgets.Extensions
{
    public static class WidgetExtension
    {
        public static async Task<IHtmlContent> Zone(this IViewComponentHelper viewComponent, string key,ICurrentResponse currentResposne)
        {
            ReadPageZoneDto pageZone = currentResposne.CurrentPage.PageZones.FirstOrDefault(x => x.Key == key);

            if (pageZone==null)
            {
                return null;
            }

            using StringWriter writer = new StringWriter();

            TagBuilder zone = new TagBuilder("section");
            zone.AddCssClass("row");
            zone.AddCssClass("zone-section");
            zone.MergeAttribute("data-zone-id", pageZone.Id.ToString());
            zone.MergeAttribute("data-zone-key", pageZone.Key);
            zone.MergeAttribute("data-zone-type", "widget");
            zone.MergeAttribute("data-zone-page-id", pageZone.Page.Id.ToString());

            if (pageZone.PageWidgets.Count <= 0)
            {
                return null;
            }

            foreach (ReadPageWidgetDto pageWidget in pageZone.PageWidgets.Where(x=>x.PageWidgetSetting.IsShow == true).OrderBy(x=>x.PageWidgetSetting.Order))
            {
                TagBuilder div = new TagBuilder("div");
                div.AddCssClass(pageWidget.PageWidgetSetting.Grid);
                div.AddCssClass(pageWidget.PageWidgetSetting.ClassCustom);
                div.MergeAttribute("data-page-widget-id", pageWidget.Id.ToString());

                IHtmlContent result = null;

                result = await viewComponent.InvokeAsync(nameof(DefaultWidgetComponent), new DefaultViewComponentInModel
                {
                    PageWidget = pageWidget
                });

                div.InnerHtml.AppendHtml(result);
                zone.InnerHtml.AppendHtml(div);
            }

            zone.WriteTo(writer, HtmlEncoder.Default);
            return new HtmlString(writer.ToString());
        }
    }
}
