using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Common.BaseClasses.Dtos.CoreEntities;
using Indivis.Core.Application.Interfaces.Dtos;
using Indivis.Core.Domain.Entities.CoreEntities.Widgets;
using Indivis.Core.Domain.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads
{
    [CreateMap(typeof(PageWidgetSetting))]
    public partial class ReadPageWidgetSettingDto : BaseReadEntityDto
    {
        public string ClassCustom { get; set; }
        public string Grid { get; set; }
        public bool IsAsync { get; set; }
        public bool IsShow { get; set; }
    }

    public partial class ReadPageWidgetSettingDto : IEntityOrderDto
    {
        public int Order { get; set; }
    }
}
