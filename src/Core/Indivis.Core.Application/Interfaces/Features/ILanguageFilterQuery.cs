using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Interfaces.Features
{
    public interface ILanguageFilterQuery
    {
        public Guid LanguageId { get; set; }
    }
}
