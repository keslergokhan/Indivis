using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Exceptions.Systems.Widgets
{
    public class NotFoundPageWidgetSettingException : Exception
    {
        public Guid PageWidgetId { get; set; }
        public string Message { get; set; }

        public NotFoundPageWidgetSettingException()
        {
            this.Message = "PageWidgetSettings değerleri bulunamadı !";
        }

        public NotFoundPageWidgetSettingException(Guid pageWidgetId):base()
        {
            this.PageWidgetId = pageWidgetId;
        }


    }
}
