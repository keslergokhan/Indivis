using Indivis.Core.Domain.Commons.CoreEntities;
using Indivis.Core.Domain.Interfaces.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Domain.Entities.CoreEntities
{
    public class EntityUrl : BaseEntity, IEntity
    {
        public Guid UrlId { get; set; }
        public Url Url { get; set; }
        public Entity Entity { get; set; }
        public Guid EntityId { get; set; }
    }
}
