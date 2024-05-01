using Indivis.Core.Domain.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Domain.Interfaces.Entities.CoreEntities
{
    public interface IEntityUrl
    {
        public Guid UrlId { get; set; }
        public Url Url { get; set; }
    }
}
