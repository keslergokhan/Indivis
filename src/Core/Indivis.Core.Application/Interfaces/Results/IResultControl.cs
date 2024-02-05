using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Interfaces.Results
{
    public interface IResultControl
    {
        public bool IsSuccess { get; }
        public IExceptionResult Error { get; }

        public IResultControl Success();
        public IResultControl Fail();
        public IResultControl Fail(Exception exception);
        public IResultControl Fail(IExceptionResult error);
    }
}
