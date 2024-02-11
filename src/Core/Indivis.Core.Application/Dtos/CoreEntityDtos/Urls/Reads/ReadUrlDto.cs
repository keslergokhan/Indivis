using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Common.BaseClasses.Dtos.CoreEntities;
using Indivis.Core.Application.Interfaces.Dtos;
using Indivis.Core.Domain.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Dtos.CoreEntityDtos.Urls.Reads
{
    [CreateMap(typeof(Url))]
    public partial class ReadUrlDto : BaseReadEntityDto, ILanguageDto
    {
        public string Path { get; set; }
        public string FullPath { get; set; }
    }

    public partial class ReadUrlDto : ILanguageDto
    {
        public Guid LanguageId { get; set; }
    }
}
