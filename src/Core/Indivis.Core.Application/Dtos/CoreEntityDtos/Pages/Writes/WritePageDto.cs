using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Common.BaseClasses.Dtos.CoreEntities;
using Indivis.Core.Application.Dtos.CoreEntityDtos.PageSystems.Reads;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Urls.Reads;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Urls.Writes;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;
using Indivis.Core.Application.Interfaces.Dtos;
using Indivis.Core.Domain.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Dtos.CoreEntityDtos.Pages.Writes
{

    [CreateMap(typeof(Page))]
    public partial class WritePageDto : BaseWriteEntityDto
    {
        public string Name { get; set; }
        public WriteUrlDto Url { get; set; }
        public Guid PageSystemId { get; set; }
    }

    public partial class WritePageDto : IEntityLanguageDto
    {
        public Guid LanguageId { get; set; }
        public Guid? ParentPageId { get; set; }
    }




}
