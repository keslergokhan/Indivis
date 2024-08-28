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
    [CreateMap(typeof(WidgetFormInput))]
    public partial class ReadWidgetFormInputDto : BaseReadEntityDto
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public bool Required { get; set; }
        public string InputComponentName { get; set; }
        public int Order { get; set; }
    }
}
