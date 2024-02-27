using Indivis.Core.Application.Interfaces.Data.Presentation;
using Indivis.Presentation.WebUI.System.Interfaces.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUI.System.Common.BaseClasses.RequestWorkers
{
    public abstract class BaseRequestWorker : IRequestWorker
    {
        private ICurrentRequest CurrentRequest;
        private IServiceProvider ServiceProvider;
        public List<IRequestWorker> RequestWorkers => new List<IRequestWorker>();

        protected BaseRequestWorker(IServiceProvider serviceProvider, ICurrentRequest currentRequest)
        {
            ServiceProvider = serviceProvider;
            CurrentRequest = currentRequest;
        }


        public void AddRequestWorker(IRequestWorker baseRequestWorker)
        {
            this.RequestWorkers.Add(baseRequestWorker);
        }

        public List<IRequestWorker> GetRequest()
        {
            return this.RequestWorkers;
        }

        public abstract ICurrentRequest ExecuteAsync();
    }
}
