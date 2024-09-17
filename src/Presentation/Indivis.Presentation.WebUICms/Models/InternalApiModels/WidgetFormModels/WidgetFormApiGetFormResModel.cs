using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;

namespace Indivis.Presentation.WebUICms.Models.InternalApiModels.WidgetFormModels
{
    public class WidgetFormApiGetFormResModel
    {
        public WidgetFormApiGetFormResModel()
        {
            this.WidgetForms = new List<ReadWidgetFormDto>();
        }

        public List<ReadWidgetFormDto> WidgetForms { get; set; }
    }
}
