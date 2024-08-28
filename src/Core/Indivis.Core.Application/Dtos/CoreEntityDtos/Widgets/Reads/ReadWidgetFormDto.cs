using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Common.BaseClasses.Dtos.CoreEntities;
using Indivis.Core.Domain.Entities.CoreEntities.ManyToMany;
using Indivis.Core.Domain.Entities.CoreEntities.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads
{
    [CreateMap(typeof(WidgetForm))]
    public partial class ReadWidgetFormDto : BaseReadEntityDto
    {
        public string Name { get; set; }
        public int Order { get; set; }
    }

    public partial class ReadWidgetFormDto
    {
        public Guid WidgetServiceId { get; set; }
        public ReadWidgetServiceDto WidgetService { get; set; }
        public List<ReadWidgetForm_WidgetFormInputDto> WidgetForm_WidgetFormInputs { get; set; }

    }



}
