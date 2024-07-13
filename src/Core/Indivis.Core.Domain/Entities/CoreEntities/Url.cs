using Indivis.Core.Domain.Commons.CoreEntities;
using Indivis.Core.Domain.Entities.CoreEntities.ManyToMany;
using Indivis.Core.Domain.Interfaces.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Domain.Entities.CoreEntities
{
    public partial class Url :BaseEntity,IEntity
    {
        public string Path { get; set; }
        public string FullPath { get; set; }
        public bool IsEntity { get; set; }

        public Guid? ParentUrlId { get; set; }
        public Url ParentUrl { get; set; }
    }

    public partial class Url : IEntityLanguage
    {
        public Guid LanguageId { get; set; }
    }

    public partial class Url
    {
        public ICollection<Url> SubUrls { get; set; }
        public UrlSystemType UrlSystemType { get; set; }
        public Guid UrlSystemTypeId { get; set; }
    }
}
