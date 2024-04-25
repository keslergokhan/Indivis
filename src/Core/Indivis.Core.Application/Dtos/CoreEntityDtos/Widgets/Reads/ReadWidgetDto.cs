using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Common.BaseClasses.Dtos.CoreEntities;
using Indivis.Core.Application.Interfaces.Dtos;
using Indivis.Core.Domain.Entities.CoreEntities.Widgets;
using Indivis.Core.Domain.Interfaces.Entities;
using Indivis.Core.Domain.Interfaces.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads
{
    [CreateMap(typeof(Widget))]
    public partial class ReadWidgetDto : BaseReadEntityDto
    {
        public ReadWidgetDto()
        {
            this.WidgetTemplates = new List<ReadWidgetTemplateDto>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
    }

    public partial class ReadWidgetDto : IEntityImageDto
    {
        public string Image { get; set; }
    }

    public partial class ReadWidgetDto : IEntityOrder
    {
        public int Order { get; set; }
    }

    public partial class ReadWidgetDto : IEntityLanguageDto
    {
        public Guid LanguageId { get; set; }
    }

    public partial class ReadWidgetDto
    {
        public List<ReadWidgetTemplateDto> WidgetTemplates { get; set; }
    }
}
