using Indivis.Core.Application.Common.BaseClasses.Dtos.CoreEntities;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Entities.Reads;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Urls.Reads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Dtos.CoreEntityDtos.EntityUrl.Writes
{
    public partial class WriteEntityUrlDto : BaseWriteEntityDto
    {
        public Guid UrlId { get; set; }
        public Guid EntityId { get; set; }
    }
}
