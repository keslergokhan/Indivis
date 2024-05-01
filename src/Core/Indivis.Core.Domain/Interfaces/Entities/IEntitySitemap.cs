using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Domain.Interfaces.Entities
{
    public interface IEntitySitemap
    {
        public bool sitemapNoIndex { get; set; }
        public bool SitemapNoWrite { get; set; }
    }
}
