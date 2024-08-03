using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Common.BaseClasses.Dtos.CoreEntities;
using System.Security.Policy;

namespace Indivis.Core.Application.Dtos.CoreEntityDtos.Urls.Writes
{
    [CreateMap(typeof(Indivis.Core.Domain.Entities.CoreEntities.Url))]
    public partial class WriteUrlDto : BaseWriteEntityDto
    {
        public string Path { get; set; }
        public string FullPath { get; set; }
        public Guid? ParentUrlId { get; set; }
        public Guid LanguageId { get; set; }
        public Guid UrlSystemTypeId { get; set; }
    }

    
}
