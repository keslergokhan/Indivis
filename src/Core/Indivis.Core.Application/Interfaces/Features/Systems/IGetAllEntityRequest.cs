using Indivis.Core.Domain.Interfaces.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Interfaces.Features.Systems
{
    public interface IGetAllEntityRequest<T> where T : class, IEntity
    {
    }
}
