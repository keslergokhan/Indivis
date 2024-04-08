using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Domain.Interfaces.Entities
{
    public interface IEntityImage
    {
        public string Image { get; set; }
    }

    public interface IEntityMobilImage
    {
        public string ImageMobile { get; set; }
    }

    
}
