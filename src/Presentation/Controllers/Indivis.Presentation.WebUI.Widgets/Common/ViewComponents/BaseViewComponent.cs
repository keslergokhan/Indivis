using AutoMapper;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;
using Indivis.Core.Application.Exceptions.Systems.Widgets;
using Indivis.Core.Application.Helpers.Systems;
using Indivis.Core.Application.Interfaces.Data.Presentation;
using Indivis.Presentation.WebUI.Widgets.Common.Models;
using Indivis.Presentation.WebUI.Widgets.Common.WidgetServices;
using Indivis.Presentation.WebUI.Widgets.Interfaces.WidgetServices;
using Indivis.Presentation.WebUI.Widgets.Models.ViewComponents;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUI.Widgets.Common.ViewComponents
{
    public abstract class BaseViewComponent : ViewComponent
    {
        protected ICurrentResponse CurrentResponse => this._serviceProvider.GetService<ICurrentResponse>();
        private readonly IServiceProvider _serviceProvider;

        protected IMapper Mapper
        {
            get
            {
                return this._serviceProvider.GetService<IMapper>();
            }
        }

        protected IMediator Mediator {
            get
            {
                return this._serviceProvider.GetService<IMediator>();
            }
        }

        public BaseViewComponent(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<object> GetWidgetServiceExecuteAsync(ReadPageWidgetDto pageWidget)
        {
            if (pageWidget.PageWidgetSetting == null)
                throw new NotFoundPageWidgetSettingException(pageWidget.Id);

            Type serviceType = SystemDependencyInjection.Instance.GetAssemblyType(Assembly.GetExecutingAssembly()
                ,pageWidget.PageWidgetSetting.WidgetTemplate.WidgetService.WidgetServiceTypeName);

            string methodName = nameof(IWidgetService<BaseWidgetServiceOutModel>.ExecuteAsync);

            object result = await SystemDependencyInjection.Instance.GeMethodInvokeAsync(serviceType, methodName, this._serviceProvider);

            return result;
        }

       
    }
}
