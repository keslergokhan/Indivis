using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Indivis.Presentation.WebUICms.Common
{
    public abstract class BaseWidgetInputComponent : ViewComponent
    {

        public T JsonParseToValue<T>(ReadWidgetFormInputDto input, ReadPageWidgetDto pageWidget) 
        {
            if (string.IsNullOrEmpty(pageWidget.WidgetJsonData))
            {
                throw new ArgumentNullException("PageWidget Json not null !");
            }



            using (JsonDocument jsonDoc = JsonDocument.Parse(pageWidget.WidgetJsonData))
            {
                JsonElement root = jsonDoc.RootElement;

                if (root.TryGetProperty(input.Name, out JsonElement value))
                {
                    return value.Deserialize<T>();
                }
                else
                {
                    throw new Exception($"No element with key value '{input.Name}' found in Json");
                }
            }



            return default(T);
        }
    }
}
