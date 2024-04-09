using Indivis.Core.Domain.Commons.CoreEntities;
using Indivis.Core.Domain.Interfaces.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Domain.Entities.CoreEntities.Widgets
{
    public partial class WidgetService : BaseEntity, IEntity
    {
        public string WidgetServiceClassName { get; set; }
        public string MethodName { get; set; }
    }
}
