using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Common.BaseClasses.Dtos.CoreEntities;
using Indivis.Core.Application.Dtos.CoreEntityDtos.PageSystems.Reads;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Urls.Reads;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;
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
        public ReadPageDto()
        {
            this.PageZones = new List<ReadPageZoneDto>();
        }

        public string Name { get; set; }
        public Guid UrlId { get; set; }
        
        public ReadUrlDto Url { get; set; }
        public ReadPageSystemDto PageSystem { get; set; }
    }

    public partial class ReadPageDto : IEntityLanguageDto
    {
        public Guid LanguageId { get; set; }
        public Guid? ParentPageId { get; set; }
        public ReadPageDto ParentPage { get; set; }
    }

    public partial class ReadPageDto
    {
        public List<ReadPageZoneDto> PageZones { get; set; }
        public List<ReadPageDto> SubPages { get; set; }
    }
}
