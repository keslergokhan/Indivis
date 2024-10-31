using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;
using Indivis.Core.Application.Interfaces.Data.Presentation;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Application.Results;
using Indivis.Presentation.WebUI.Widgets.Common.WidgetServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUI.Widgets.WidgetServices.CkEditorWidget
{
    [DependencyRegister(typeof(CkEditorService), DependencyTypes.Scopet)]
    public class CkEditorService : BaseWidgetService<CkEditorServiceOutModel>
    {
        public readonly ICurrentResponse _currentResponse;

        public CkEditorService(ICurrentResponse currentResponse)
        {
            _currentResponse = currentResponse;
        }

        public override async Task<IResultDataControl<CkEditorServiceOutModel>> ExecuteAsync(ReadPageWidgetDto pageWidget)
        {
            IResultDataControl<CkEditorServiceOutModel> model = new ResultDataControl<CkEditorServiceOutModel>();
            model.SetData(base.JsonConvertToModel(pageWidget));

            try
            {
            }
            catch (Exception exception)
            {
                model.Fail(exception);
            }

            return model;
        }
    }

   
}
