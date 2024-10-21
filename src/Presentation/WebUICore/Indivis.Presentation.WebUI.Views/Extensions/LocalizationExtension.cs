using Indivis.Core.Application.Dtos.CoreEntityDtos.Localization.Reads;
using Indivis.Core.Application.Helpers;
using Indivis.Core.Application.Interfaces.Data.Presentation;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Encodings.Web;

namespace Indivis.Presentation.WebUI.Views.Extensions
{
    public static class LocalizationExtension
    {
        private static string LocalizationAttrBuilder(string key,ReadLocalizationDto localization,string value,bool isWidgetLocalizaton)
        {
            Random random = new Random();

            int randomNumber = random.Next(1000000, 9999999);

            using StringWriter writer = new StringWriter();

            TagBuilder baseSpan = new TagBuilder("span");

            baseSpan.InnerHtml.AppendHtml(value);
            baseSpan.Attributes.Add("data-loc-key", key);
            baseSpan.Attributes.Add("data-loc-id", localization.Id.ToString());
            baseSpan.Attributes.Add("id", $"loc-key-{randomNumber.ToString()}");
            baseSpan.Attributes.Add("data-is-page", localization.IsPageLocalization.ToString());
            baseSpan.Attributes.Add("data-is-backend", localization.IsBackendLocalization.ToString());
            baseSpan.Attributes.Add("data-is-htmleditor", localization.IsHtmlEditor.ToString());
            if (isWidgetLocalizaton)
            {
                baseSpan.AddCssClass("cms-loc-key js-cms-widget-loc-key");
            }
            else
            {
                baseSpan.AddCssClass("cms-loc-key js-cms-loc-key");
            }

            baseSpan.WriteTo(writer, HtmlEncoder.Default);

            return writer.ToString();
        }
        public static async Task<IHtmlContent> PageLocalizationAsync(this IHtmlHelper htmlHelper, string key, ICurrentResponse currentResposne,string defautlValue = null)
        {
            ReadLocalizationDto localization = await LocalizationHelper.GetLocalizationAsync(key ,currentResposne,defautlValue);
            
            string value = string.Empty;

            if (localization!=null)
            {
                if (localization.Region.Any())
                {
                    value = localization.Region.FirstOrDefault().Value;
                }
                else
                {
                    value = localization.DefaultValue;
                }
            }

            if (currentResposne.EditMode)
            {

                string html = LocalizationExtension.LocalizationAttrBuilder(key,localization,value,false);
                return htmlHelper.Raw(html);
            }
            else
            {
                return htmlHelper.Raw(value);
            }
            
        }


        public static async Task<IHtmlContent> PageWidgetLocalizationAsync(this IHtmlHelper htmlHelper, string key, ICurrentResponse currentResposne, string defautlValue = null)
        {
            ReadLocalizationDto localization = await LocalizationHelper.GetLocalizationAsync(key, currentResposne, defautlValue);

            string value = string.Empty;

            if (localization != null)
            {
                if (localization.Region.Any())
                {
                    value = localization.Region.FirstOrDefault().Value;
                }
                else
                {
                    value = localization.DefaultValue;
                }
            }

            if (currentResposne.EditMode)
            {

                string html = LocalizationExtension.LocalizationAttrBuilder(key, localization, value, true);
                return htmlHelper.Raw(html);
            }
            else
            {
                return htmlHelper.Raw(value);
            }

        }
    }
}
