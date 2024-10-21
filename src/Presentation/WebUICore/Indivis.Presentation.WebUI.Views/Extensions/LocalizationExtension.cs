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
                Random random = new Random();

                int randomNumber = random.Next(1000000, 9999999);

                using StringWriter writer = new StringWriter();

                TagBuilder baseSpan = new TagBuilder("span");

                baseSpan.InnerHtml.AppendHtml(value);
                baseSpan.Attributes.Add("data-loc-key",key);
                baseSpan.Attributes.Add("data-loc-id",localization.Id.ToString());
                baseSpan.Attributes.Add("id",$"loc-key-{randomNumber.ToString()}");
                baseSpan.Attributes.Add("data-is-page", localization.IsPageLocalization.ToString());
                baseSpan.Attributes.Add("data-is-backend", localization.IsBackendLocalization.ToString());
                baseSpan.Attributes.Add("data-is-htmleditor", localization.IsHtmlEditor.ToString());

                baseSpan.AddCssClass("cms-loc-key js-cms-loc-key");

                baseSpan.WriteTo(writer, HtmlEncoder.Default);
                return htmlHelper.Raw(writer.ToString());
            }
            else
            {
                return htmlHelper.Raw(value);
            }
            
        }
    }
}
