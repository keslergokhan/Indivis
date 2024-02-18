using Indivis.Core.Application.Common.BaseClasses.Dtos.CoreEntities;
using Indivis.Core.Application.Interfaces.Data.Presentation;
using Indivis.Presentation.WebUI.System.Interfaces.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUI.System.Common.RequestWorkers
{
    public class PageRequestWorker : BaseReadEntityDto, IRequestWorker
    {
        public async Task<ICurrentRequest> ExecuteAsync()
        {
            throw new NotImplementedException();
        }
    }
}
