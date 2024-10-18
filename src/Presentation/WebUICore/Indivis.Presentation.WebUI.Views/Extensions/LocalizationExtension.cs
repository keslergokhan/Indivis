using Indivis.Core.Application.Common.Data.Presentation;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Language.Reads;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Localization.Reads;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Localization.Writes;
using Indivis.Core.Application.Features.Systems.Commands.Localizations;
using Indivis.Core.Application.Features.Systems.Queries.Localizations;
using Indivis.Core.Application.Helpers;
using Indivis.Core.Application.Interfaces.Data.Presentation;
using Indivis.Core.Application.Interfaces.Results;
using MediatR;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

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
                using StringWriter writer = new StringWriter();

                TagBuilder baseSpan = new TagBuilder("span");

                baseSpan.InnerHtml.AppendHtml(value);
                baseSpan.Attributes.Add("data-loc-key",key);
                baseSpan.Attributes.Add("data-loc-id",localization.Id.ToString());
                
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
