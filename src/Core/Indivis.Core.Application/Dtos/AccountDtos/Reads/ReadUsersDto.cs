using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Common.BaseClasses.Dtos.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Dtos.AccountDtos.Reads
{
    [CreateMap(typeof(Indivis.Core.Domain.Entities.IApplicationUser))]
    public class ReadUsersDto : BaseReadEntityDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
