using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Attributes
{
    public class PageWidgetJsonConvertFailedException : Exception
    {
        private string _message;
        public string Message { get { return _message;} }

        public PageWidgetJsonConvertFailedException(Guid pageWidgetId)
        {
            this._message = $"PageWidgetId = {pageWidgetId.ToString()} WidgetJsonData değeri deserilize edilemiyor!";
        }
    }
}
