using Indivis.Core.Application.Interfaces.Data.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUI.System.Interfaces.BaseClasses
{
    public interface IRequestWorker
    {
        public Task<ICurrentRequest> ExecuteAsync();
    }
}
