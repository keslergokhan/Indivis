using Indivis.Core.Application.Commons.Dtos;
using Indivis.Core.Application.Dtos.CoreEntities.Reads.Urls;
using Indivis.Core.Application.Interfaces.Dtos.Reads;
using Indivis.Core.Domain.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Dtos.CoreEntities.Reads.Pages
{
    public partial class ReadPageDto : BaseReadEntityDto
    {
        public string Name { get; set; }
        public ReadUrlDto Url { get; set; }
        public Guid UrlId { get; set; }
    }

    public partial class ReadPageDto : IReadEntityLanguageDto
    {
        public Guid LanguageId { get; set; }
    }
}
