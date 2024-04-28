using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Presentation.WebUI.Controllers.Common.ViewComponents
{
    public class BaseViewComponent : ViewComponent
    {
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
    }
}
