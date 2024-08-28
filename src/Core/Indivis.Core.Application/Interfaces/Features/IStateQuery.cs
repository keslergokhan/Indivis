using Indivis.Core.Application.Enums.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Interfaces.Features
{
    public interface IStateQuery
    {
        public StateEnum State { get; set; }
    }
}
