using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Common.BaseClasses.Dtos.CoreEntities;
using Indivis.Core.Domain.Entities.CoreEntities.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads
{
    [CreateMap(typeof(WidgetService))]
    public class ReadWidgetServiceDto : BaseReadEntityDto
    {
        public string WidgetServiceClassName { get; set; }
    }
}
