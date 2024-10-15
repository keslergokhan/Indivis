using Indivis.Core.Domain.Commons.CoreEntities;
using Indivis.Core.Domain.Interfaces.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Domain.Entities.CoreEntities
{
    public partial class LocalizationRegion : BaseEntity
    {
        public string Value { get; set; }
    }

    public partial class LocalizationRegion : IEntityLanguagePro
    {
        public Guid LanguageId { get; set; }
        public Language Language { get; set; }
    }

    public partial class LocalizationRegion
    {
        public Guid LocalizationId { get; set; }
        public Localization Localization { get; set; }
    }

}
