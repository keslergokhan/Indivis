using Indivis.Core.Application.Interfaces.Data.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUI.System.Interfaces.BaseClasses
{
    public interface IBaseRequestWorker
    {
        new List<IBaseRequestWorker> BaseRequestWorkers { get; }
        public void AddRequestWorker(IBaseRequestWorker baseRequestWorker);
        public List<IBaseRequestWorker> GetRequest();
        public ICurrentRequest Execute();
    }
}
