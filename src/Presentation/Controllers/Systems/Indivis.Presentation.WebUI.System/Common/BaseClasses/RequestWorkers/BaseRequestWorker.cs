using Indivis.Core.Application.Interfaces.Data.Presentation;
using Indivis.Presentation.WebUI.System.Interfaces.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUI.System.Common.BaseClasses.RequestWorkers
{
    public abstract class BaseRequestWorker : IBaseRequestWorker
    {
        private IServiceProvider _serviceProvider;

        protected BaseRequestWorker(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public List<IBaseRequestWorker> BaseRequestWorkers => new List<IBaseRequestWorker>();

        public void AddRequestWorker(IBaseRequestWorker baseRequestWorker)
        {
            this.BaseRequestWorkers.Add(baseRequestWorker);
        }

        public ICurrentRequest Execute()
        {
            throw new NotImplementedException();
        }

        public List<IBaseRequestWorker> GetRequest()
        {
            return this.BaseRequestWorkers;
        }
    }
}
