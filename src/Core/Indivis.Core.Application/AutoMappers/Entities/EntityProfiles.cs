using AutoMapper;
using Indivis.Core.Application.Dtos.CoreEntities.Reads.Entities;
using Indivis.Core.Application.Dtos.CoreEntities.Reads.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.AutoMappers.Entities
{
    public class EntityProfiles : Profile
    {
        public EntityProfiles()
        {
            CreateMap<EntityProfiles, ReadEntityDto>();
        }
    }
}
