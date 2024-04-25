using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Common.BaseClasses.Dtos.CoreEntities;
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
    [CreateMap(typeof(PageWidget))]
    public partial class ReadPageWidgetDto : BaseReadEntityDto
    {
    }
    public partial class ReadPageWidgetDto : IEntityLanguageDto
    {
        public Guid LanguageId { get; set; }
    }

    public partial class ReadPageWidgetDto
    {
        public ReadPageZoneDto PageZone { get; set; }
        public Guid PageZoneId { get; set; }

        public ReadWidgetDto Widget { get; set; }
        public Guid WidgetId { get; set; }

        public ReadPageWidgetSettingDto PageWidgetSetting { get; set; }
        public Guid PageWidgetSettingId { get; set; }
    }
}
