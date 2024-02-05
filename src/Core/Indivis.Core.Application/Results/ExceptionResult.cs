using Indivis.Core.Application.Interfaces.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Results
{
    public class ExceptionResult : IExceptionResult
    {
        private string _title;

        

        public string Title => _title;

        private string _message;
        public string Message => _message;

        private Exception _exception;
        public Exception Exception => _exception;

        public ExceptionResult()
        {
            
        }

        public ExceptionResult(string title)
        {
            this._title = title;
        }

        public ExceptionResult(string title,string message):this(title)
        {
            this._message = message;
        }

        public ExceptionResult(string title, string message,Exception exception) : this(title, message)
        {
            this._exception = exception;
        }

        public IExceptionResult SetMessage(string message)
        {
            _message = message;
            return this;
        }

        public IExceptionResult SetTitle(string title)
        {
            _title = title;
            return this;
        }

        public IExceptionResult SetException(Exception exception)
        {
            _exception = exception;
            return this;
        }

        public IExceptionResult ErrorReadLogger()
        {
            return this;
        }
    }
}
