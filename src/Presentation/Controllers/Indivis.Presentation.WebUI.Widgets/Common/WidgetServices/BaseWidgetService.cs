using Indivis.Core.Application.Attributes;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Presentation.WebUI.Widgets.Common.Models;
using Indivis.Presentation.WebUI.Widgets.Interfaces.WidgetServices;
using System.Text.Json;

namespace Indivis.Presentation.WebUI.Widgets.Common.WidgetServices
{
    public abstract class BaseWidgetService<TModel>
        : IWidgetService<TModel>
        where TModel : BaseWidgetServiceOutModel,new()
    {
        public TModel JsonConvertToModel(ReadPageWidgetDto pageWidget)
        {
            if (string.IsNullOrEmpty(pageWidget.WidgetJsonData))
            {
                throw new Exception($"{pageWidget.Widget.Name} json bulunamdaı !");
            }

            try
            {
                return JsonSerializer.Deserialize<TModel>(pageWidget.WidgetJsonData);
                
            }
            catch(Exception ex)
            {
                throw new PageWidgetJsonConvertFailedException(pageWidget.Id);
            }

            return default(TModel);
        }
        public abstract Task<IResultDataControl<TModel>> ExecuteAsync(ReadPageWidgetDto pageWidget);
    }
}
