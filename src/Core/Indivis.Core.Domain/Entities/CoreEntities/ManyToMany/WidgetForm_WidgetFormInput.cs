using Indivis.Core.Domain.Entities.CoreEntities.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Domain.Entities.CoreEntities.ManyToMany
{
    public class WidgetForm_WidgetFormInput
    {
        public WidgetForm WidgetForm { get; set; }
        public Guid WidgetFormId { get; set; }

        public WidgetFormInput WidgetFormInput { get; set; }
        public Guid WidgetFormInputId { get; set; }
    }
}
