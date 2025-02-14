﻿using Indivis.Core.Application.Common.BaseClasses.Features.Queries;
using Indivis.Core.Application.Dtos.CoreEntityDtos.PageSystems.Reads;
using Indivis.Core.Application.Interfaces.Features.FeatureFactories;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Domain.Entities.CoreEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Features.Systems.Queries.Pages
{
    public class GetPageSystemByIdSystemQuery:
        BaseGetByIdEntityDataQuery<PageSystem,ReadPageSystemDto>,
        IRequest<IResultDataControl<ReadPageSystemDto>>,
        IQueryFactory<GetPageSystemByIdSystemQuery>

    {
    }

    public class GetPageSystemByIdHandler :
        BaseGetByIdEntityDataHandlerQuery<PageSystem,ReadPageSystemDto>,
        IRequestHandler<GetPageSystemByIdSystemQuery, IResultDataControl<ReadPageSystemDto>>

    {
        public GetPageSystemByIdHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<IResultDataControl<ReadPageSystemDto>> Handle(GetPageSystemByIdSystemQuery request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }

}
