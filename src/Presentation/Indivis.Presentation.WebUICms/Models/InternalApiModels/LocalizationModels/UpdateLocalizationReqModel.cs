using Indivis.Core.Application.Dtos.CoreEntityDtos.Localization.Writes;

namespace Indivis.Presentation.WebUICms.Models.InternalApiModels.LocalizationModels
{
    public class UpdateLocalizationReqModel
    {
        public UpdateLocalizationReqItemModel Localization { get; set; }
    }

    public class UpdateLocalizationReqItemModel
    {
        public Guid LocalizationId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}