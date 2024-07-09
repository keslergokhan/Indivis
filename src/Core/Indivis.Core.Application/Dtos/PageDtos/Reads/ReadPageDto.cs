using Indivis.Core.Domain.Entities.CoreEntities.Widgets;
using Indivis.Core.Domain.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Urls.Reads;
using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Common.BaseClasses.Dtos.CoreEntities;

namespace Indivis.Core.Application.Dtos.PageDtos.Reads
{
    [CreateMap(typeof(Page))]
    public class ReadPageDto : BaseReadEntityDto
    {
        public string Name { get; set; }
        public ReadUrlDto Url { get; set; }
        public Guid UrlId { get; set; }
        public Guid LanguageId { get; set; }
        public Guid PageSystemId { get; set; }
        public ReadPageSystemDto PageSystem { get; set; }

    }
}
