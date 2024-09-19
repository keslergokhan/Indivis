using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Common.BaseClasses.Dtos.CoreEntities;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;
using Indivis.Core.Application.Interfaces.Dtos;
using Indivis.Core.Domain.Entities.CoreEntities.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Writes
{
    [CreateMap(typeof(PageWidgetSetting))]
    public partial class WritePageWidgetSettingDto : BaseWriteEntityDto
    {
        public string Name { get; set; }
        public string ClassCustom { get; set; }
        public string Grid { get; set; }
        public bool IsAsync { get; set; }
        public bool IsShow { get; set; }
    }

    public partial class WritePageWidgetSettingDto : IEntityOrderDto
    {
        public int Order { get; set; }
    }
    public partial class WritePageWidgetSettingDto
    {
        public Guid WidgetTemplateId { get; set; }
    }
}
