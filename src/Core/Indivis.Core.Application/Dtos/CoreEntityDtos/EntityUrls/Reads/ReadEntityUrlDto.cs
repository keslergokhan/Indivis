using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Entities.Reads;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Urls.Reads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Dtos.CoreEntityDtos.EntityUrl.Reads
{
    [CreateMap(typeof(Indivis.Core.Domain.Entities.CoreEntities.EntityUrl))]
    public partial class ReadEntityUrlDto
    {
        public Guid UrlId { get; set; }
        public ReadUrlDto Url { get; set; }
        public ReadEntityDto Entity { get; set; }
        public Guid EntityId { get; set; }
    }
}
