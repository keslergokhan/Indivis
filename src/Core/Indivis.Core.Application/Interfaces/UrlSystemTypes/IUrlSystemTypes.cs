using Indivis.Core.Application.Interfaces.Data.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUI.System.Interfaces.Workers
{
    public interface IUrlSystemTypes
    {
        public List<IUrlSystemTypes> UrlSystemTypes { get; }
        public void AddRequestWorker(IUrlSystemTypes baseRequestWorker);
        public List<IUrlSystemTypes> GetRequest();
        public ICurrentRequest ExecuteAsync();
    }
}
