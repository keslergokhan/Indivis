using Indivis.Core.Application.Commons.Dtos;
using Indivis.Core.Application.Interfaces.Dtos.Reads;
using Indivis.Core.Domain.Entities.CoreEntities.ManyToMany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Dtos.CoreEntities.Reads.Urls
{
    public class ReadUrlSystemTypeDto : BaseReadEntityDto
    {
        public string InterfaceType { get; set; }
        public List<ReadUrl_UrlSystemTypeDto> Url_UrlSystemTypes { get; set; }
    }
}
