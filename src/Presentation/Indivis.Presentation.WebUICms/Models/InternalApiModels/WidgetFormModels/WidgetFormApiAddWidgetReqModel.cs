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
        [JsonPropertyName("widgetTemplateId")]
        public Guid WidgetTemplateId { get; set; }
        public bool IsShow { get; set; }
        [JsonPropertyName("pageId")]
        public Guid PageId { get; set; }
        public Guid WidgetId { get; set; }
        [JsonPropertyName("pageZoneId")]
        public Guid PageZoneId { get; set; }
    }
}
