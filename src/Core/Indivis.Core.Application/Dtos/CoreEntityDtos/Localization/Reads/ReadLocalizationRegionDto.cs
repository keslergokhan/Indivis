using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Common.BaseClasses.Dtos.CoreEntities;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Language.Reads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Dtos.CoreEntityDtos.Localization.Reads
{
    [CreateMap(typeof(Indivis.Core.Domain.Entities.CoreEntities.LocalizationRegion))]
    public partial class ReadLocalizationRegionDto : BaseReadEntityDto
    {
        public string Value { get; set; }
    }

    public partial class ReadLocalizationRegionDto
    {
        public Guid LanguageId { get; set; }
        public ReadLanguageDto Language { get; set; }
    }

    public partial class ReadLocalizationRegionDto
    {
        public Guid LocalizationId { get; set; }
        public ReadLocalizationDto Localization { get; set; }
    }
}
