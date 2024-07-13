using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Domain.Entities.CoreEntities.ManyToMany
{
    public class Url_UrlSystemType
    {
        public Guid UrlId { get; set; }
        public Url Url { get; set; }
        public Guid UrlSystemTypeId { get; set; }
        public UrlSystemType UrlSystemType { get; set; }
        public int Order { get; set; }
    }
}
