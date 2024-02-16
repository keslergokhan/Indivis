using Indivis.Core.Application.Common.BaseClasses.Features.Queries;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Urls.Reads;
using Indivis.Core.Application.Interfaces.Features.Systems;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Domain.Entities.CoreEntities;
using MediatR;

namespace Indivis.Core.Application.Features.Systems.Queries.Urls
{
    public class GetByIdUrlQuery :
         BaseGetByIdEntityDataQuery<Url, ReadUrlDto>,
         IRequest<IResultDataControl<ReadUrlDto>>,
         IGetByIdEntityQuery<Url>
    {

    }

    public class GetByIdUrlQueryHandler : BaseGetByIdEntityDataHandlerQuery<Url, ReadUrlDto>, IRequestHandler<GetByIdUrlQuery, IResultDataControl<ReadUrlDto>>
    {

        public GetByIdUrlQueryHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }
        public async Task<IResultDataControl<ReadUrlDto>> Handle(GetByIdUrlQuery request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
