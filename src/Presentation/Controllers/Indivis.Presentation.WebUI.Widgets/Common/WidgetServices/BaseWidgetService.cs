using Indivis.Core.Application.Interfaces.Results;
using Indivis.Presentation.WebUI.Widgets.Common.Models;
using Indivis.Presentation.WebUI.Widgets.Interfaces.WidgetServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUI.Widgets.Common.WidgetServices
{
    public abstract class BaseWidgetService<TModel>
        : IWidgetService<TModel>
        where TModel : BaseWidgetServiceOutModel,new()
    {
        public abstract Task<IResultDataControl<TModel>> ExecuteAsync();
    }
}
