using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Common.BaseClasses.Dtos.CoreEntities;
using Indivis.Core.Application.Dtos.CoreEntityDtos.ManyToMany;
using Indivis.Core.Application.Interfaces.Dtos;
using Indivis.Core.Domain.Entities.CoreEntities;
using Indivis.Core.Domain.Entities.CoreEntities.ManyToMany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Dtos.CoreEntityDtos.Urls.Reads
{
    [CreateMap(typeof(Url))]
    public partial class ReadUrlDto : BaseReadEntityDto, IEntityLanguageDto
    {
        public string Path { get; set; }
        public string FullPath { get; set; }
        public Guid ParentUrlId { get; set; }
        public ReadUrlDto ParentUrl { get; set; }
    }

    public partial class ReadUrlDto : IEntityLanguageDto
    {
        public Guid LanguageId { get; set; }
    }

    public partial class ReadUrlDto
    {
        public ICollection<ReadUrlDto> SubUrls { get; set; }
        public ICollection<ReadUrl_UrlSystemTypeDto> Url_UrlSystemTypes { get; set; }
    }
}
