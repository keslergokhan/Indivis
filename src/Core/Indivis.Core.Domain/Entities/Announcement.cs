using Indivis.Core.Domain.Commons.CoreEntities;
using Indivis.Core.Domain.Interfaces.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Domain.Entities
{
    public partial class Announcement : BaseEntity
    {
    }

    public partial class Announcement : BaseEntity, IEntityLanguage
    {
        public Guid LanguageId { get; set; }
    }

    public partial class Announcement : BaseEntity, IEntityDefaultColumnTitle
    {
        public string Title { get; set; }
    }
}
