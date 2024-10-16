using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Language.Reads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Dtos.CoreEntityDtos.Localization.Writes
{
    [CreateMap(typeof(Indivis.Core.Domain.Entities.CoreEntities.LocalizationRegion))]
    public partial class WriteLocalizationRegionDto
    {
        public string Value { get; set; }
    }
    public partial class WriteLocalizationRegionDto
    {
        public Guid LanguageId { get; set; }
    }
    public partial class WriteLocalizationRegionDto
    {
        public Guid LocalizationId { get; set; }
    }
}
