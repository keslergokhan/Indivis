using Indivis.Core.Application.Commons.Dtos;
using Indivis.Core.Application.Interfaces.Dtos.Reads;
using Indivis.Core.Domain.Commons.CoreEntities;
using Indivis.Core.Domain.Entities.CoreEntities;
using Indivis.Core.Domain.Entities.CoreEntities.ManyToMany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Dtos.CoreEntities.Reads.Urls
{
    public partial class ReadUrlDto :BaseReadEntityDto, IReadEntityDto
    {
        public string Path { get; set; }
        public string FullPath { get; set; }

        public Guid? ParentUrlId { get; set; }
        public ReadUrlDto ParentUrl { get; set; }
    }

    public partial class ReadUrlDto : IReadEntityLanguageDto
    {
        public Guid LanguageId { get; set; }
    }

    public partial class ReadUrlDto
    {
        public List<ReadUrlDto> SubUrls { get; set; }
        public List<ReadUrl_UrlSystemTypeDto> Url_UrlSystemTypes { get; set; }
    }
}
