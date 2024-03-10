using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Urls.Reads;
using Indivis.Core.Application.Dtos.CoreEntityDtos.UrlSystemType.Reads;
using Indivis.Core.Domain.Entities.CoreEntities;
using Indivis.Core.Domain.Entities.CoreEntities.ManyToMany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Dtos.CoreEntityDtos.ManyToMany
{
    [CreateMap(typeof(Url_UrlSystemType))]
    public class ReadUrl_UrlSystemTypeDto
    {
        public Guid UrlId { get; set; }
        public ReadUrlDto Url { get; set; }
        public Guid UrlSystemTypeId { get; set; }
        public ReadUrlSystemTypeDto UrlSystemType { get; set; }
    }
}
