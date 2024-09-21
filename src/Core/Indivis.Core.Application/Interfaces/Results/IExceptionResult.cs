using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Interfaces.Results
{
    public interface IExceptionResult
    {
        public string Title { get; }
        public string Message { get; }
        [JsonIgnore]
        public Exception Exception { get; }



        public IExceptionResult SetException(Exception exception);
        public IExceptionResult SetTitle(string title);
        public IExceptionResult SetMessage(string message);
        public IExceptionResult ErrorReadLogger();
        

    }

   
}
