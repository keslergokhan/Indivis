using Indivis.Core.Domain.Commons.CoreEntities;
using Indivis.Core.Domain.Interfaces.Entities;
using Indivis.Core.Domain.Interfaces.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Domain.Entities.CoreEntities
{
    public partial class WidgetTemplate : BaseEntity, IEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Template { get; set; }
        public bool IsDefault { get; set; }
    }

    public partial class WidgetTemplate : IEntityImage
    {
        public string Image { get; set; }
    }

    public partial class WidgetTemplate : IEntityLanguage
    {
        public Guid LanguageId { get; set; }
    }

    public partial class WidgetTemplate
    {
        public Widget Widget { get; set; }
        public Guid WidgetId { get; set; }
        public WidgetService WidgetService { get; set; }
        public Guid WidgetServiceId { get; set; }
    }
}
