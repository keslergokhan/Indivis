using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Domain.Interfaces.Entities.CoreEntities
{
    public interface IEntityLanguage : IEntity
    {
        public Guid LanguageId { get; set; }
    }
}
