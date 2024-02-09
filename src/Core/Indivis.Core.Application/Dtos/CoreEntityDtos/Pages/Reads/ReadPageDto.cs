using Indivis.Core.Application.Attributes.System;
using Indivis.Core.Application.Common.Dtos.CoreEntities;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Urls.Reads;
using Indivis.Core.Application.Interfaces.Dtos;
using Indivis.Core.Domain.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Dtos.CoreEntityDtos.Pages.Reads
{
    [CreateMap(typeof(Page))]
    public partial class ReadPageDto : BaseReadEntityDto
    {
        public string Name { get; set; }
        public Guid UrlId { get; set; }
        
        public ReadUrlDto Url { get; set; }
    }

    public partial class ReadPageDto : IReadLanguageDto
    {
        public Guid LanguageId { get; set; }
    }
}
