using Indivis.Core.Application.Commons.Dtos;
using Indivis.Core.Application.Interfaces.Dtos.Reads;
using Indivis.Core.Domain.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Dtos.CoreEntities.Reads.Urls
{
    public class ReadUrl_UrlSystemTypeDto
    {
        public Guid UrlId { get; set; }
        public ReadUrlDto Url { get; set; }
        public Guid UrlSystemTypeId { get; set; }
        public ReadUrlSystemTypeDto UrlSystemType { get; set; }
    }
}
