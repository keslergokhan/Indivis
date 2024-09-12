using Indivis.Core.Application.Dtos.CoreEntityDtos.Pages.Reads;
using Indivis.Core.Application.Dtos.CoreEntityDtos.PageSystems.Reads;
using Indivis.Core.Application.Dtos.CoreEntityDtos.UrlSystemType.Reads;
using Indivis.Presentation.WebUICms.Common;

namespace Indivis.Presentation.WebUICms.Models.PageModels
{
    public class CreatePageViewResModel : BaseViewResModel
    {
        public ReadPageSystemDto PageSystem { get; set; }
        public ReadPageDto ParentPage { get; set; }
    }
}
