﻿using Indivis.Core.Application.Common.BaseClasses.Features.Queries;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Urls.Reads;
using Indivis.Core.Application.Interfaces.Features.FeatureFactories;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Domain.Entities.CoreEntities;
using MediatR;

namespace Indivis.Core.Application.Features.Systems.Queries.Urls
{
    public class GetByIdUrlSystemQuery :
         BaseGetByIdEntityDataQuery<Url, ReadUrlDto>,
         IRequest<IResultDataControl<ReadUrlDto>>,
         IQueryFactory<GetByIdUrlSystemQuery>
    {

    }

    public class GetByIdUrlQueryHandler : BaseGetByIdEntityDataHandlerQuery<Url, ReadUrlDto>, IRequestHandler<GetByIdUrlSystemQuery, IResultDataControl<ReadUrlDto>>
    {

        public GetByIdUrlQueryHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }
        public async Task<IResultDataControl<ReadUrlDto>> Handle(GetByIdUrlSystemQuery request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
