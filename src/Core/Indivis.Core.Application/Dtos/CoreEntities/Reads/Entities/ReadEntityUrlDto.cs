using Indivis.Core.Application.Commons.Dtos;
using Indivis.Core.Application.Dtos.CoreEntities.Reads.Urls;
using Indivis.Core.Domain.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Dtos.CoreEntities.Reads.Entities
{
    public partial class ReadEntityUrlDto : BaseReadEntityDto
    {
        public Guid UrlId { get; set; }
        public ReadUrlDto Url { get; set; }
        public ReadEntityDto Entity { get; set; }
        public Guid EntityId { get; set; }
    }
}
