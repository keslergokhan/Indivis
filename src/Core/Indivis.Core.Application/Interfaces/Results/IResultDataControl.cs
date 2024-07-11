using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Interfaces.Results
{
    public interface IResultDataControl
    {
        public object GetDataObject();
    }
    public interface IResultDataControl<T> : IResultControl, IResultDataControl
    {
        public T Data { get; }
        public IResultDataControl<T> SetData(T t);

        public IResultDataControl<T> SuccessSetData(T t);

    }

}
