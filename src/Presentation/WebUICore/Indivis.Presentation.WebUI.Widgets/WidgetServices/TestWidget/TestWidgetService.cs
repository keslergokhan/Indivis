using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;
using Indivis.Core.Application.Interfaces.Data.Presentation;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Application.Results;
using Indivis.Presentation.WebUI.Widgets.Common.WidgetServices;
using Indivis.Presentation.WebUI.Widgets.Models.TestWidget;

namespace Indivis.Presentation.WebUI.Widgets.WidgetServices.TestWidget
{
    [DependencyRegister(typeof(TestWidgetService), DependencyTypes.Scopet)]
    public class TestWidgetService : BaseWidgetService<TestWidgetOutModel>
    {
        private readonly ICurrentResponse _currentResponse;

        public TestWidgetService(ICurrentResponse currentResponse)
        {
            _currentResponse = currentResponse;
        }

        public async override Task<IResultDataControl<TestWidgetOutModel>> ExecuteAsync(ReadPageWidgetDto pageWidget)
        {
            IResultDataControl<TestWidgetOutModel> model = new ResultDataControl<TestWidgetOutModel>();
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
