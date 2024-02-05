using Indivis.Core.Application.Common.Results;
using Indivis.Core.Application.Interfaces.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Results
{
    public class DataResultControl<T> : BaseResultControl, IDataResultControl<T>
    {
        private T _data;
        public T Data => _data;

        public IDataResultControl<T> SetData(T t)
        {
            _data = t;
            return this;
        }

        public IDataResultControl<T> SuccessSetData(T t)
        {
            this.SetData(t);
            base.Success();
            return this;
        }
    }
}
