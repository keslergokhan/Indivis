using Indivis.Core.Application.Common.BaseClasses.Features.Queries;
using Indivis.Core.Application.Dtos.CoreEntityDtos.UrlSystemType.Reads;
using Indivis.Core.Application.Interfaces.Features.FeatureFactories;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Domain.Entities.CoreEntities;
using MediatR;

namespace Indivis.Core.Application.Features.Systems.Queries.UrlSystemTypes
{
    public class GetByIdUrlSystemTypeSystemQuery :
         BaseGetByIdEntityDataQuery<UrlSystemType, ReadUrlSystemTypeDto>,
         IRequest<IResultDataControl<ReadUrlSystemTypeDto>>,
         IQueryFactory<GetByIdUrlSystemTypeSystemQuery>
    {

    }

    public class GetByIdUrlSystemTypeQueryHandler : BaseGetByIdEntityDataHandlerQuery<UrlSystemType, ReadUrlSystemTypeDto>, IRequestHandler<GetByIdUrlSystemTypeSystemQuery, IResultDataControl<ReadUrlSystemTypeDto>>
    {

        public GetByIdUrlSystemTypeQueryHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }
        public async Task<IResultDataControl<ReadUrlSystemTypeDto>> Handle(GetByIdUrlSystemTypeSystemQuery request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
