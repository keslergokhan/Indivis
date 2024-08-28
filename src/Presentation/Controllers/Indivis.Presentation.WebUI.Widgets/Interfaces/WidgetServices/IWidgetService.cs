using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Presentation.WebUI.Widgets.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUI.Widgets.Interfaces.WidgetServices
{
    public interface IWidgetService<TModel>
         where TModel : BaseWidgetServiceOutModel, new()
    {
        public Task<IResultDataControl<TModel>> ExecuteAsync(ReadPageWidgetDto pageWidget);
    }
}
