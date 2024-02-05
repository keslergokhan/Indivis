using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Interfaces.Results
{
    public interface IDataResultControl<T> : IResultControl
    {
        public T Data { get; }
        public IDataResultControl<T> SetData(T t);

        public IDataResultControl<T> SuccessSetData(T t);
    }

}
