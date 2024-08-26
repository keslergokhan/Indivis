using Indivis.Core.Domain.Commons.CoreEntities;
using Indivis.Core.Domain.Entities.CoreEntities.ManyToMany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Domain.Entities.CoreEntities.Widgets
{
    public partial class WidgetFormInput : BaseEntity
    {
        
        public string Name { get; set; }
        public string Label { get; set; }
        public bool Required { get; set; }
        public string InputComponentName { get; set; }
    }

    public partial class WidgetFormInput
    {
        public ICollection<WidgetForm_WidgetFormInput> WidgetForm_WidgetFormInputs { get; set; }
    }
}
