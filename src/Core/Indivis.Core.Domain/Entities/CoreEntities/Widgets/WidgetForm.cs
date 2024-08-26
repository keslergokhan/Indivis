using Indivis.Core.Domain.Commons.CoreEntities;
using Indivis.Core.Domain.Entities.CoreEntities.ManyToMany;
using Indivis.Core.Domain.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Domain.Entities.CoreEntities.Widgets
{
    public partial class WidgetForm : BaseEntity, IEntityOrder
    {
        public string Name { get; set; }
        
        public int Order { get; set; }
    }

    public partial class WidgetForm : BaseEntity
    {
        public Guid WidgetServiceId { get; set; }
        public WidgetService WidgetService { get; set; }

        public ICollection<WidgetForm_WidgetFormInput> WidgetForm_WidgetFormInputs { get; set; }
    }
}
