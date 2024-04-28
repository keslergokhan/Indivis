using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Application.Results;
using Indivis.Presentation.WebUI.Widgets.Common.Models;
using Indivis.Presentation.WebUI.Widgets.Common.WidgetServices;
using Indivis.Presentation.WebUI.Widgets.Interfaces.WidgetServices;
using Indivis.Presentation.WebUI.Widgets.Models.TestWidget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUI.Widgets.WidgetServices.TestWidget
{
    [DependencyRegister(typeof(TestWidgetService), DependencyTypes.Scopet)]
    public class TestWidgetService : BaseWidgetService<TestWidgetOutModel>
    {
        public async override Task<IResultDataControl<TestWidgetOutModel>> ExecuteAsync()
        {
            IResultDataControl<TestWidgetOutModel> model = new ResultDataControl<TestWidgetOutModel>();

            try
            {
                TestWidgetOutModel data = new TestWidgetOutModel();
                data.Title = "Merhaba dünya";
                model.SuccessSetData(data);
            }
            catch (Exception exception)
            {
                model.Fail(exception);
            }

            return model;
        }

       
    }
}
