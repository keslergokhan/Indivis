using Indivis.Core.Domain.Commons.CoreEntities;
using Indivis.Core.Domain.Entities.CoreEntities.ManyToMany;
using Indivis.Core.Domain.Interfaces.Entities;
using Indivis.Core.Domain.Interfaces.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Domain.Entities.CoreEntities
{
    /// <summary>
    /// Url yapısının hangi sınıflar aracılığı ile çalıştırılacağını belirtir.
    /// </summary>
    public class UrlSystemType : BaseEntity
    {
        public string InterfaceType { get; set; }
    }
}
