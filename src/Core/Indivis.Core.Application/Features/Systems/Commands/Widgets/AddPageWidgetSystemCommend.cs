﻿using AutoMapper;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Writes;
using Indivis.Core.Application.Enums.Systems;
using Indivis.Core.Application.Interfaces.Data;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Application.Results;
using Indivis.Core.Domain.Entities.CoreEntities.Widgets;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Features.Systems.Commands.Widgets
{
    public class AddPageWidgetSystemCommend : IRequest<IResultDataControl<ReadPageWidgetDto>>
    {
        public WritePageWidgetDto PageWidget { get; set; }
    }

    public class AddPageWidgetSystemCommendHandler : IRequestHandler<AddPageWidgetSystemCommend, IResultDataControl<ReadPageWidgetDto>>
    {
        private readonly IMapper _mapper;

        private readonly IApplicationDbContext _applicationDbContext;
        public AddPageWidgetSystemCommendHandler(IMapper mapper, IApplicationDbContext applicationDbContext)
        {
            _mapper = mapper;
            _applicationDbContext = applicationDbContext;
        }


        public async Task<IResultDataControl<ReadPageWidgetDto>> Handle(AddPageWidgetSystemCommend request, CancellationToken cancellationToken)
        {
            IResultDataControl<ReadPageWidgetDto> model = new ResultDataControl<ReadPageWidgetDto>();
            try
            {
                PageWidget pageWidget = this._mapper.Map<PageWidget>(request.PageWidget);

                PageWidgetSetting setting = await this._applicationDbContext.PageWidgets.Where(x => x.PageZoneId == request.PageWidget.PageZoneId).OrderBy(x => x.PageWidgetSetting.Order)
                    .Select(x=>x.PageWidgetSetting).OrderByDescending(x=>x.Order).FirstOrDefaultAsync();

                if (setting!=null)
                {
                    pageWidget.PageWidgetSetting.Order = setting.Order + 1;
                }
                else
                {
                    pageWidget.PageWidgetSetting.Order = 0;
                }

                

                EntityEntry<PageWidget> entityEntry = await this._applicationDbContext.PageWidgets.AddAsync(pageWidget);

                int saveChanges = await this._applicationDbContext.SaveChangesAsync();

                if (saveChanges <= 0)
                {
                    throw new Exception($"PageWidget kayıt edilemedi ! {request.PageWidget.PageWidgetSetting.Name}  { request.PageWidget.PageZoneId}");
                }

                
                model.SuccessSetData(this._mapper.Map<ReadPageWidgetDto>(entityEntry.Entity));
                entityEntry.State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }
            catch (Exception ex)
            {
                model.Fail(ex);
            }

            return model;
        }
    }
}
