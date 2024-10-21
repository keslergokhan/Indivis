using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Common.BaseClasses.Dtos.CoreEntities;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Localization.Reads;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Pages.Reads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Dtos.CoreEntityDtos.Localization.Writes
{
    [CreateMap(typeof(Indivis.Core.Domain.Entities.CoreEntities.Localization))]
    public partial class WriteLocalizationDto : BaseWriteEntityDto
    {
        public string Key { get; set; }
        public string DefaultValue { get; set; }
        public Guid? PageId { get; set; }
        public bool IsPageLocalization { get; set; }
        public bool IsBackendLocalization { get; set; }
        public bool IsWidget { get; set; }
    }

    public partial class WriteLocalizationDto
    {
        public List<WriteLocalizationRegionDto> Region { get; set; }
    }
}
