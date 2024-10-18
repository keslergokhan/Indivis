using System.Text.Json.Serialization;

namespace Indivis.Presentation.WebUICms.Models.InternalApiModels.WidgetFormModels
{

    public class WidgetFormApiUpdateWidgetReqModel
    {
        public WidgetFormApiUpdateWidgetReqSettingModel WidgetSetting { get; set; }
        public object WidgetData { get; set; }
    }

    public class WidgetFormApiUpdateWidgetReqSettingModel
    {
        [JsonPropertyName("PageWidgetSettingId")]
        public Guid PageWidgetSettingId { get; set; }
        [JsonPropertyName("PageWidgetId")]
        public Guid PageWidgetId { get; set; }
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
        public int Order { get; set; }
    }
}
