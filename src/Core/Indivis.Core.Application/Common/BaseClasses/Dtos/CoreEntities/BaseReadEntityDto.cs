using Indivis.Core.Application.Interfaces.Dtos.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Common.BaseClasses.Dtos.CoreEntities
{
    public abstract class BaseReadEntityDto : IReadEntityDto
    {
        public Guid Id { get; set; }
    }
}
