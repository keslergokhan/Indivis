using Indivis.Core.Domain.Commons.CoreEntities;
using Indivis.Core.Domain.Interfaces.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Domain.Entities.CoreEntities.Widgets
{
    public partial class PageZone : BaseEntity, IEntity
    {
        public string Key { get; set; }
        public Page Page { get; set; }
        public Guid PageId { get; set; }
    }

    public partial class PageZone : IEntityLanguage
    {
        public Guid LanguageId { get; set; }
    }

    public partial class PageZone
    {
        public ICollection<PageWidget> PageWidgets { get; set; }
    }
}
