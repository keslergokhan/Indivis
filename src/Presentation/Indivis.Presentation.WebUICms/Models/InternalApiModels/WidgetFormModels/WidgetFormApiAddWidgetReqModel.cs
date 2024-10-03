using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;
using System.Text.Json.Serialization;

namespace Indivis.Presentation.WebUICms.Models.InternalApiModels.WidgetFormModels
{
    public class WidgetFormApiAddWidgetReqModel
    {
        public WidgetFormApiAddWidgetReqSettingModel WidgetSetting { get; set; }
        public object WidgetData { get; set; }
    }

    public class WidgetFormApiAddWidgetReqSettingModel
    {
        public string Name { get; set; }
        public string Grid { get; set; }
        [JsonPropertyName("WidgetTemplateId")]
        public Guid WidgetTemplateId { get; set; }
        public bool IsShow { get; set; }
        [JsonPropertyName("PageId")]
        public Guid PageId { get; set; }
        public Guid WidgetId { get; set; }
        [JsonPropertyName("PageZoneId")]
        public Guid PageZoneId { get; set; }
    }
}
