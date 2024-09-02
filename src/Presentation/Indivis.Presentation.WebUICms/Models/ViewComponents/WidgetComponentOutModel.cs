using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUICms.Models.ViewComponents
{
    public class WidgetComponentOutModel
    {
        public WidgetComponentOutModel()
        {
            this.Widgets = new List<ReadWidgetDto>();
        }
        public List<ReadWidgetDto> Widgets { get; set; }
    }
}
