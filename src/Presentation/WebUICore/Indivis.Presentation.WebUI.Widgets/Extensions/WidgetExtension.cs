﻿using Indivis.Core.Application.Common.Data.Presentation;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;
using Indivis.Core.Application.Interfaces.Data.Presentation;
using Indivis.Core.Domain.Entities.CoreEntities.Widgets;
using Indivis.Presentation.WebUI.Widgets.Models.ViewComponents;
using Indivis.Presentation.WebUI.Widgets.ViewComponents.Widgets;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.CompilerServices;
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

            TagBuilder baseDiv = new TagBuilder("div");
            baseDiv.AddCssClass("zone-widgets-container");
            if (pageZone.PageWidgets.Count <= 0)
            {
                baseDiv.AddCssClass("empty-widgets-container");
                zone.InnerHtml.AppendHtml(baseDiv);
                zone.WriteTo(writer, HtmlEncoder.Default);
                return new HtmlString(writer.ToString());
            }

            List<ReadPageWidgetDto> pageWidgets = new List<ReadPageWidgetDto>();

            if (currentResposne.EditMode)
                pageWidgets = pageZone.PageWidgets.OrderBy(x => x.PageWidgetSetting.Order).ToList();
            else
                pageWidgets = pageZone.PageWidgets.Where(x => x.PageWidgetSetting.IsShow == true).OrderBy(x => x.PageWidgetSetting.Order).ToList();

            if (!currentResposne.EditMode)
            {
                foreach (ReadPageWidgetDto pageWidget in pageWidgets)
                {
                    TagBuilder div = new TagBuilder("div");
                    div.AddCssClass(pageWidget.PageWidgetSetting.Grid);
                    div.AddCssClass(pageWidget.PageWidgetSetting.ClassCustom);
                    div.MergeAttribute("data-page-widget-id", pageWidget.Id.ToString());
                    div.MergeAttribute("data-widget-id", pageWidget.WidgetId.ToString());
                    div.MergeAttribute("data-widget-templage-id", pageWidget.PageWidgetSetting.WidgetTemplateId.ToString());


                    IHtmlContent content = null;

                    if (!currentResposne.EditMode)
                    {
                        content = await viewComponent.InvokeAsync(nameof(DefaultWidgetComponent), new DefaultViewComponentInModel
                        {
                            PageWidget = pageWidget
                        });
                    }
                    else
                    {
                        div.AddCssClass("empty-widget cms-spinner-border");
                    }


                    div.InnerHtml.AppendHtml(content);
                    baseDiv.InnerHtml.AppendHtml(div);

                }
            }
            
            zone.InnerHtml.AppendHtml(baseDiv);
            zone.WriteTo(writer, HtmlEncoder.Default);
            HtmlString result = new HtmlString(writer.ToString());
            writer.Close();
            writer.Dispose();
            return result;
        }

        /// <summary>
        /// Html widget tasarımı döner
        /// </summary>
        /// <param name="viewComponent"></param>
        /// <param name="pageWidget"></param>
        /// <returns></returns>
        public static async Task<IHtmlContent> Widget(this IViewComponentHelper viewComponent,ReadPageWidgetDto pageWidget)
        {
            using (StringWriter writer = new StringWriter())
            {
                IHtmlContent content = null;

                content = await viewComponent.InvokeAsync(nameof(DefaultWidgetComponent), new DefaultViewComponentInModel
                {
                    PageWidget = pageWidget
                });

                content.WriteTo(writer, HtmlEncoder.Default);
                HtmlString result = new HtmlString(writer.ToString());
                writer.Close();
                writer.Dispose();
                return result;
            }
            
        }
    }
}
