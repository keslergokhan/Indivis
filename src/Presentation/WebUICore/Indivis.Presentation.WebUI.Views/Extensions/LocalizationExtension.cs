using Indivis.Core.Application.Interfaces.Data.Presentation;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUI.Views.Extensions
{
    public static class LocalizationExtension
    {
        public static async Task<IHtmlContent> Localization(this IViewComponentHelper viewComponent, string key, ICurrentResponse currentResposne)
        {


            return null;
        }
    }
}
