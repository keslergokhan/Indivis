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
        protected IServiceProvider ServiceProvider;
        public List<IUrlSystemTypes> UrlSystemTypes => new List<IUrlSystemTypes>();

        protected BaseUrlSystemTypes(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }


        public void AddRequestWorker(IUrlSystemTypes baseRequestWorker)
        {
            this.UrlSystemTypes.Add(baseRequestWorker);
        }

        public List<IUrlSystemTypes> GetRequest()
        {
            return this.UrlSystemTypes;
        }

        public abstract ICurrentRequest ExecuteAsync();
    }
}
