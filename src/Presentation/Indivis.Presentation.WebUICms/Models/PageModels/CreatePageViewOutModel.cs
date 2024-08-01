using Indivis.Core.Application.Dtos.CoreEntityDtos.Pages.Reads;
using Indivis.Core.Application.Dtos.CoreEntityDtos.PageSystems.Reads;

namespace Indivis.Presentation.WebUICms.Models.PageModels
{
    public class CreatePageViewOutModel
    {
        public ReadPageSystemDto PageSystem { get; set; }
        public ReadPageDto ParentPage { get; set; }
    }
}
