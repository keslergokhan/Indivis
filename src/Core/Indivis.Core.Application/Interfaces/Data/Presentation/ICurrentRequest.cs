using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Interfaces.Data.Presentation
{

    public interface ICurrentRequest
    {
        public string Schema { get; set; }
        public string Domain { get; set; }
        public string Region { get; set; }
        public string Path { get; set; }
        public string FullPath { get; set; }
        public string BaseUrl { get; set; }
        public bool EditMode { get; set; }
    }
}
