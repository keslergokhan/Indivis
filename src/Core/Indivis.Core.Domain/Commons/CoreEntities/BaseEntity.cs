using Indivis.Core.Domain.Interfaces.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Domain.Commons.CoreEntities
{
    public abstract class BaseEntity : IEntity
    {
        public Guid Id { get; set; }
        public byte State { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
