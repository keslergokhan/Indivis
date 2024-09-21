using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;
using Indivis.Presentation.WebUICms.Common;

namespace Indivis.Presentation.WebUICms.Models.InternalApiModels.WidgetFormModels
{
    public class WidgetFormApiAddWidgetResModel : BaseApiResModel
    {
        public ReadPageWidgetDto PageWidget { get; set; }
    }
}
