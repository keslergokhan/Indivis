using Indivis.Core.Application.Common.BaseClasses.Results;
using Indivis.Core.Application.Interfaces.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Results
{
    public class ResultDataControl<T> : BaseResultControl, IResultDataControl<T>
    {
        public ResultDataControl()
        {
            
        }

        public ResultDataControl(T d)
        {
            this._data = d;
        }

        private T _data;
        public T Data => _data;

        public object GetDataObject()
        {
            return this.Data;
        }

        public IResultDataControl<T> SetData(T t)
        {
            _data = t;
            return this;
        }

        public IResultDataControl<T> SuccessSetData(T t)
        {
            this.SetData(t);
            base.Success();
            return this;
        }

    }
}
