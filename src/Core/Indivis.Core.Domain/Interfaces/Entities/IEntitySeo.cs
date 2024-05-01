using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Domain.Interfaces.Entities
{
    public interface IEntitySeo
    {
        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public string SeoBreadcrumbTitle { get; set; }
    }

}
