using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUI.Widgets.Models.ViewComponents
{
    public class WidgetFormComponentOutModel
    {
        public WidgetFormComponentOutModel()
        {
            this.WidgetFormList = new List<ReadWidgetFormDto>();
        }
        public List<ReadWidgetFormDto> WidgetFormList { get; set; }
    }
}
