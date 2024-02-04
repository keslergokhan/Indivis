using AutoMapper;
using Indivis.Core.Application.Dtos.CoreEntities.Reads.Languages;
using Indivis.Core.Domain.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.AutoMappers.Entities
{
    public class LanguageProfiles : Profile
    {
        public LanguageProfiles()
        {
            CreateMap<Language, ReadLanguageDto>();
        }
    }
}
