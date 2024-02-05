using Indivis.Core.Application.Interfaces.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Common.Dtos
{
    public abstract class BaseReadEntityDto : IReadEntityDto
    {
        public Guid Id { get; set; }
    }
}
