using Indivis.Core.Application.Common.BaseClasses.Dtos.CoreEntities;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Urls.Reads;
using Indivis.Core.Application.Interfaces.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Dtos.CoreEntityDtos.Pages.Writes
{
    public partial class WritePageDto : BaseWriteEntityDto
    {
        public string Name { get; set; }
        public Guid UrlId { get; set; }
    }

    public partial class ReadPageDto
    {

    }
}
