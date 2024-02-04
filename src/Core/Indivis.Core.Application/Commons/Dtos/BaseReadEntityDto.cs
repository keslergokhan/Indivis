using Indivis.Core.Application.Interfaces.Dtos.Reads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Commons.Dtos
{
    public class BaseReadEntityDto : IReadEntityDto
    {
        public Guid Id { get; set; }
    }
}
