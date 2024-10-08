﻿using Indivis.Core.Application.Common.BaseClasses.Features.Queries;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Entities.Reads;
using Indivis.Core.Application.Interfaces.Features.FeatureFactories;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Domain.Entities.CoreEntities;
using MediatR;

namespace Indivis.Core.Application.Features.EntityUrls.Queries
{
    public class GetByIdEntityQuery :
        BaseGetByIdEntityDataQuery<Entity, ReadEntityDto>,
        IRequest<IResultDataControl<ReadEntityDto>>,
        IQueryFactory<GetByIdEntityQuery>
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
