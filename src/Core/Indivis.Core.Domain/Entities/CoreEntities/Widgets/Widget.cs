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
    public partial class Widget : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public partial class Widget : IEntityImage
    {
        public string Image { get; set; }
    }

    public partial class Widget : IEntityOrder
    {
        public int Order { get; set; }
    }

    public partial class Widget : IEntityLanguage
    {
        public Guid LanguageId { get; set; }
    }

    public partial class Widget
    {
        public ICollection<WidgetTemplate> WidgetTemplates { get; set; }
    }
}
