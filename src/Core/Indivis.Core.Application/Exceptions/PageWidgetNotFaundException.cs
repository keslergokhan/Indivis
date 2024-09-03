using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Exceptions
{
    public class PageWidgetNotFaundException : Exception
    {
        private string _message;
        public string Message { get { return _message; } }
        public PageWidgetNotFaundException()
        {
            this._message = "Veritabanında PageWidget değerine ulaşılamadı !";
        }

        public PageWidgetNotFaundException(Guid pageWidgetId)
        {
            this._message = $"Veritabanında PageWidget değerine ulaşılamadı, PageWidgetId = {pageWidgetId.ToString()}";
        }
    }
}
