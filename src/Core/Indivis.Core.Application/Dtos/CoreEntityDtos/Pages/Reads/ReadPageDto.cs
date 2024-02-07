using Indivis.Core.Application.Common.Dtos.CoreEntities;
using Indivis.Core.Domain.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Dtos.CoreEntityDtos.Pages.Reads
{
    public class ReadPageDto : BaseReadEntityDto
    {
        public string Name { get; set; }
        public Guid UrlId { get; set; }
    }
}
