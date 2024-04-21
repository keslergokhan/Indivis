using Indivis.Core.Domain.Commons.CoreEntities;
using Indivis.Core.Domain.Interfaces.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Domain.Entities.CoreEntities
{
    /// <summary>
    /// Sayfanın çalıştırılacağı Controller ve method değerleri
    /// </summary>
    public class PageSystem : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }

        public ICollection<Page> Pages { get; set; }
    }
}
