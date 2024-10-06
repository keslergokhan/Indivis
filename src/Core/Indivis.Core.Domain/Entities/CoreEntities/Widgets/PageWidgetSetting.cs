using Indivis.Core.Domain.Commons.CoreEntities;
using Indivis.Core.Domain.Interfaces.Entities;
using Indivis.Core.Domain.Interfaces.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Domain.Entities.CoreEntities.Widgets
{
    public partial class PageWidgetSetting : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public string ClassCustom { get; set; }
        public string Grid { get; set; }
        public bool IsAsync { get; set; }
        public bool IsShow { get; set; }

    }

    public partial class PageWidgetSetting : IEntityOrder
    {
        public int Order { get; set; }
    }

    public partial class PageWidgetSetting
    {
        public Guid WidgetTemplateId { get; set; }
        public WidgetTemplate WidgetTemplate { get; set; }
    }
}
