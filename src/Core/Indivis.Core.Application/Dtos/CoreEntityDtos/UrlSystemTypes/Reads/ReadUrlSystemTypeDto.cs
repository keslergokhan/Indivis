using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Common.BaseClasses.Dtos.CoreEntities;
using Indivis.Core.Domain.Entities.CoreEntities.ManyToMany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Dtos.CoreEntityDtos.UrlSystemType.Reads
{
    [CreateMap(typeof(Indivis.Core.Domain.Entities.CoreEntities.UrlSystemType))]
    public partial class ReadUrlSystemTypeDto : BaseReadEntityDto
    {
        public string InterfaceType { get; set; }
        public ReadUrlSystemTypeDto Url_UrlSystemTypes { get; set; }
    }
}
