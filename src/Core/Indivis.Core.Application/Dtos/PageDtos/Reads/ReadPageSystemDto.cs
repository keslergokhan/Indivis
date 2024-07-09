using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Common.BaseClasses.Dtos.CoreEntities;
using Indivis.Core.Domain.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Dtos.PageDtos.Reads
{
    [CreateMap(typeof(PageSystem))]
    public class ReadPageSystemDto : BaseReadEntityDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }

        public ICollection<ReadPageDto> Pages { get; set; }
    }
}
