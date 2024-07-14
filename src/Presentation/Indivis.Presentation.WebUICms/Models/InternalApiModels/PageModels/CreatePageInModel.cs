using Indivis.Core.Application.Dtos.CoreEntityDtos.Pages.Reads;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Urls.Reads;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json.Serialization;

namespace Indivis.Presentation.WebUICms.Models.InternalApiModels.PageModels
{
    public class CreatePageInModel
    {
        public string Slug { get; set; }
        public string Name { get; set; }

    }
}
