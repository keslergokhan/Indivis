using Indivis.Core.Application.Common.BaseClasses.Features.Queries;
using Indivis.Core.Application.Dtos.CoreEntityDtos.UrlSystemType.Reads;
using Indivis.Core.Application.Interfaces.Features.FeatureFactories;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Domain.Entities.CoreEntities;
using MediatR;

namespace Indivis.Core.Application.Features.UrlSystemTypes.Queries
{
    public class GetByIdUrlSystemTypeQuery :
         BaseGetByIdEntityDataQuery<UrlSystemType, ReadUrlSystemTypeDto>,
         IRequest<IResultDataControl<ReadUrlSystemTypeDto>>,
         IQueryFactory<GetByIdUrlSystemTypeQuery>
    {

    }

    public class GetByIdUrlSystemTypeQueryHandler : BaseGetByIdEntityDataHandlerQuery<UrlSystemType, ReadUrlSystemTypeDto>, IRequestHandler<GetByIdUrlSystemTypeQuery, IResultDataControl<ReadUrlSystemTypeDto>>
    {

        public GetByIdUrlSystemTypeQueryHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }
        public async Task<IResultDataControl<ReadUrlSystemTypeDto>> Handle(GetByIdUrlSystemTypeQuery request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
