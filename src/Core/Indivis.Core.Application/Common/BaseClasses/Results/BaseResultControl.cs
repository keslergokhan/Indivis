using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Application.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Common.BaseClasses.Results
{
    public abstract class BaseResultControl : IResultControl
    {
        protected bool _isSuccess;
        public bool IsSuccess => _isSuccess;

        private IExceptionResult _error;
        public IExceptionResult Error => _error;

        public BaseResultControl()
        {
            _isSuccess = true;
        }
        public IResultControl Success()
        {
            _isSuccess = true;
            return this;
        }

        public IResultControl Fail()
        {
            return this;
        }

        public IResultControl Fail(string title, string message)
        {
            return this;
        }

        public IResultControl Fail(string title, string message, Exception exception)
        {
            return this;
        }

        public IResultControl Fail(IExceptionResult error)
        {
            _error = error;
            return this;
        }

        public IResultControl Fail(Exception exception)
        {
            _error = new ExceptionResult(exception.Source, exception.Message, exception);
            return this;
        }
    }
}
