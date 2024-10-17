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
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUI.Views.Extensions
{
    public static class LocalizationExtension
    {

        public static async Task<IHtmlContent> PageLocalization(this IHtmlHelper htmlHelper, string key, ICurrentResponse currentResposne,string defautlValue = null)
        {
            ReadLocalizationDto localization = await LocalizationHelper.GetLocalizationAsync(key ,currentResposne,defautlValue);

            if (localization!=null)
            {
                if (localization.Region.Any())
                    return htmlHelper.Raw(localization.Region.FirstOrDefault());
                else
                    return htmlHelper.Raw(localization.DefaultValue);
            }

            return htmlHelper.Raw(key);
        }
    }
}
