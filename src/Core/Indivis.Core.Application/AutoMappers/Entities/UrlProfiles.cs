using AutoMapper;
using Indivis.Core.Application.Dtos.CoreEntities.Reads.Urls;
using Indivis.Core.Domain.Entities.CoreEntities;
using Indivis.Core.Domain.Entities.CoreEntities.ManyToMany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.AutoMappers.Entities
{
    public class UrlProfiles : Profile
    {
        public UrlProfiles()
        {
            CreateMap<Url, ReadUrlDto>();
            CreateMap<UrlSystemType,ReadUrlSystemTypeDto>();
            CreateMap<Url_UrlSystemType,ReadUrl_UrlSystemTypeDto>();
        }
    }
}
