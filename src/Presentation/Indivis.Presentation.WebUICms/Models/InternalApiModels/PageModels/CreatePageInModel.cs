using Indivis.Core.Application.Dtos.CoreEntityDtos.Pages.Reads;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Urls.Reads;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json.Serialization;

namespace Indivis.Presentation.WebUICms.Models.InternalApiModels.PageModels
{
    public class CreatePageInModel
    {
        public string FullPath { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public Guid ParentPageId { get; set; }
        public Guid ParentUrlId { get; set; }
        public Guid PageSystemId { get; set; }
        public Guid UrlSystemTypeId { get; set; }

    }
}
