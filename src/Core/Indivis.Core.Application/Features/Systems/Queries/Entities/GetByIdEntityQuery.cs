﻿using Indivis.Core.Application.Common.BaseClasses.Features.Queries;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Entities.Reads;
using Indivis.Core.Application.Features.Systems.Queries.Pages;
using Indivis.Core.Application.Interfaces.Features.Systems;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Domain.Entities.CoreEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Features.Systems.Queries.Entities
{
    public class GetByIdEntityQuery :
        BaseGetByIdEntityDataQuery<Entity, ReadEntityDto>,
        IRequest<IResultDataControl<ReadEntityDto>>,
        IGetByIdEntityQuery<Page>
    {

    }
    public class GetByIdEntityQueryHandler : BaseGetByIdEntityDataHandlerQuery<Entity, ReadEntityDto>, IRequestHandler<GetByIdEntityQuery, IResultDataControl<ReadEntityDto>>
    {

        public GetByIdEntityQueryHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        public async Task<IResultDataControl<ReadEntityDto>> Handle(GetByIdEntityQuery request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }


}