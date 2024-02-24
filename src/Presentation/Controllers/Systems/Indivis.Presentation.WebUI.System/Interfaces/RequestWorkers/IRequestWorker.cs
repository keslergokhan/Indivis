using Indivis.Core.Application.Interfaces.Data.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUI.System.Interfaces.Workers
{
    public interface IRequestWorker
    {
        public List<IRequestWorker> RequestWorkers { get; }
        public void AddRequestWorker(IRequestWorker baseRequestWorker);
        public List<IRequestWorker> GetRequest();
        public ICurrentRequest ExecuteAsync();
    }
}
