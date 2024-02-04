using AutoMapper;
using Indivis.Core.Application.Dtos.CoreEntities.Reads.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.AutoMappers.Entities
{
    public class PageProfiles : Profile
    {
        public PageProfiles()
        {
            CreateMap<PageProfiles, ReadPageDto>();
        }
    }
}
