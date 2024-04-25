using Indivis.Core.Domain.Commons.CoreEntities;
using Indivis.Core.Domain.Interfaces.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Domain.Entities.CoreEntities.Widgets
{
    public partial class PageWidget : BaseEntity, IEntity
    {
    }

    public partial class PageWidget : IEntityLanguage
    {
        public Guid LanguageId { get; set; }
    }

    public partial class PageWidget
    {
        public PageZone PageZone { get; set; }
        public Guid PageZoneId { get; set; }

        public Widget Widget { get; set; }
        public Guid WidgetId { get; set; }

        public PageWidgetSetting PageWidgetSetting { get; set; }
        public Guid PageWidgetSettingId { get; set; }
    }
}
