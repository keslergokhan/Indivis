using Indivis.Core.Domain.Commons.CoreEntities;
using Indivis.Core.Domain.Entities.CoreEntities.Widgets;
using Indivis.Core.Domain.Interfaces.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Domain.Entities.CoreEntities
{
    public partial class Page : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public Url Url { get; set; }
        public Guid UrlId { get; set; }
    }

    public partial class Page : IEntityLanguage
    {
        public Guid LanguageId { get; set; }
    }

    public partial class Page {
        public Guid PageSystemId { get; set; }
        public PageSystem PageSystem { get; set; }

        public ICollection<PageZone> PageZones { get; set; }
    }

   
}
