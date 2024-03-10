using Indivis.Core.Application.Interfaces.Data.Presentation;
using Indivis.Presentation.WebUI.System.Interfaces.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUI.System.Common.BaseClasses.RequestWorkers
{
    public abstract class BaseUrlSystemTypes : IUrlSystemTypes
    {
        private ICurrentRequest CurrentRequest;
        private IServiceProvider ServiceProvider;
        public List<IUrlSystemTypes> RequestWorkers => new List<IUrlSystemTypes>();

        protected BaseUrlSystemTypes(IServiceProvider serviceProvider, ICurrentRequest currentRequest)
        {
            ServiceProvider = serviceProvider;
            CurrentRequest = currentRequest;
        }


        public void AddRequestWorker(IUrlSystemTypes baseRequestWorker)
        {
            this.RequestWorkers.Add(baseRequestWorker);
        }

        public List<IUrlSystemTypes> GetRequest()
        {
            return this.RequestWorkers;
        }

        public abstract ICurrentRequest ExecuteAsync();
    }
}
