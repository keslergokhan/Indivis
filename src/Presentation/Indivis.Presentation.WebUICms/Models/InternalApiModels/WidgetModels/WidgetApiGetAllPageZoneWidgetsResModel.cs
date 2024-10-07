using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;

namespace Indivis.Presentation.WebUICms.Models.InternalApiModels.WidgetModels
{
    public class WidgetApiGetAllPageZoneWidgetsResModel
    {
        public WidgetApiGetAllPageZoneWidgetsResModel()
        {
            this.PageWidget = new List<ReadPageWidgetDto>();
        }
        public List<ReadPageWidgetDto> PageWidget { get; set; }
    }
}
