using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Common.BaseClasses.Dtos.CoreEntities;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Pages.Reads;
using Indivis.Core.Application.Interfaces.Dtos;
using Indivis.Core.Domain.Entities.CoreEntities.Widgets;
using Indivis.Core.Domain.Interfaces.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads
{
    [CreateMap(typeof(PageZone))]
    public partial class ReadPageZoneDto : BaseReadEntityDto
    {
        public ReadPageZoneDto()
        {
            this.PageWidgets = new List<ReadPageWidgetDto>();
        }

        public string Key { get; set; }
        public ReadPageDto Page { get; set; }
        public Guid PageId { get; set; }
    }

    public partial class ReadPageZoneDto : IEntityLanguageDto
    {
        public Guid LanguageId { get; set; }
    }

    public partial class ReadPageZoneDto
    {
        public List<ReadPageWidgetDto> PageWidgets { get; set; }
    }
}
