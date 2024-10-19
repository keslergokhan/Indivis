using Indivis.Core.Domain.Commons.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Domain.Entities.CoreEntities
{
    public partial class Localization : BaseEntity
    {
        public string Key { get; set; }
        public string DefaultValue { get; set; }
        public Guid? PageId { get; set; }
        public Page Page { get; set; }
        public bool IsPageLocalization { get; set; }
        public bool IsBackendLocalization { get; set; }
        public bool IsHtmlEditor { get; set; }
    }

    public partial class Localization
    {
        public ICollection<LocalizationRegion> Region { get; set; }
    }
}
