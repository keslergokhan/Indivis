using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Common.BaseClasses.Dtos.CoreEntities;
using Indivis.Core.Application.Interfaces.Dtos;
using Indivis.Core.Domain.Entities.CoreEntities.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Writes
{
    [CreateMap(typeof(PageWidget))]
    public partial class WritePageWidgetDto : BaseWriteEntityDto
    {
        public Guid PageZoneId { get; set; }

        public Guid WidgetId { get; set; }

        public WritePageWidgetSettingDto PageWidgetSetting { get; set; }
        public Guid PageWidgetSettingId { get; set; }
        public string WidgetJsonData { get; set; }
    }

    public partial class WritePageWidgetDto : IEntityLanguageDto
    {
        public Guid LanguageId { get; set; }
    }
}
