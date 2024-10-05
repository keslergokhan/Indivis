using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;

namespace Indivis.Presentation.WebUICms.Models.InternalApiModels.WidgetFormModels
{
    public class WidgetFormApiGetDynamicUpdateFormResModel
    {
        public WidgetFormApiGetDynamicUpdateFormResModel()
        {
            this.WidgetForms = new List<ReadWidgetFormDto>();
        }

        public List<ReadWidgetFormDto> WidgetForms { get; set; }
        public ReadPageWidgetDto PageWidget { get; set; }
    }
}
