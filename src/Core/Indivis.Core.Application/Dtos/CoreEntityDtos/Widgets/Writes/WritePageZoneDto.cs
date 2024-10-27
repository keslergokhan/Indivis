using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Common.BaseClasses.Dtos.CoreEntities;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Pages.Reads;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Pages.Writes;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;
using Indivis.Core.Domain.Entities.CoreEntities.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Writes
{
    [CreateMap(typeof(PageZone))]
    public partial class WritePageZoneDto : BaseWriteEntityDto
    {
        public string Key { get; set; }
        public WritePageDto Page { get; set; }
        public Guid PageId { get; set; }
    }

    public partial class WritePageZoneDto
    {
        public Guid LanguageId { get; set; }
        public List<WritePageWidgetDto> PageWidgets { get; set; }

    }
}
