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
    public class Url :BaseEntity,IEntity, IEntityLanguage
    {
        public Guid LanguageId { get; set; }
        public string Path { get; set; }
        public string FullPath { get; set; }

        public Guid? ParentUrlId { get; set; }
        public Url ParentUrl { get; set; }



        public ICollection<Url> SubUrls { get; set; }
        public ICollection<Url_UrlSystemType> Url_UrlSystemTypes { get; set; }
    }
}
