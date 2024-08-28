using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Domain.Entities.CoreEntities.ManyToMany;
using Indivis.Core.Domain.Entities.CoreEntities.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads
{
    [CreateMap(typeof(WidgetForm_WidgetFormInput))]
    public class ReadWidgetForm_WidgetFormInputDto
    {
        public ReadWidgetFormDto WidgetForm { get; set; }
        public Guid WidgetFormId { get; set; }

        public ReadWidgetFormInputDto WidgetFormInput { get; set; }
        public Guid WidgetFormInputId { get; set; }
    }
}
