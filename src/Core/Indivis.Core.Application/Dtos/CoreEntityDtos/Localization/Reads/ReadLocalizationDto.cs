using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Common.BaseClasses.Dtos.CoreEntities;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Pages.Reads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Dtos.CoreEntityDtos.Localization.Reads
{
    [CreateMap(typeof(Indivis.Core.Domain.Entities.CoreEntities.Localization))]
    public partial class ReadLocalizationDto : BaseReadEntityDto
    {
        public string Key { get; set; }
        public string DefaultValue { get; set; }
        public Guid? PageId { get; set; }
        public ReadPageDto Page { get; set; }
        public bool IsPageLocalization { get; set; }
        public bool IsBackendLocalization { get; set; }
        public bool IsHtmlEditor { get; set; }
    }

    public partial class ReadLocalizationDto
    {
        public List<ReadLocalizationRegionDto> Region { get; set; }
    }
}
