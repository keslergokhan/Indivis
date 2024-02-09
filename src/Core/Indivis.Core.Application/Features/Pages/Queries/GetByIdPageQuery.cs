using AutoMapper;
using Indivis.Core.Application.Common.Data;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Pages.Reads;
using Indivis.Core.Application.Features.Generic.Queries;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Domain.Entities.CoreEntities;
using MediatR;

namespace Indivis.Core.Application.Features.Pages.Queries
{
    public class GetByIdPageQuery : GetByIdEntityDataQuery<Page,ReadPageDto>,IRequest<IResultDataControl<ReadPageDto>>
    {
    }

    public class GetByIdPageQueryHandler : GetByIdEntityDataHandlerQuery<Page,ReadPageDto>, IRequestHandler<GetByIdPageQuery, IResultDataControl<ReadPageDto>>
    {
        public GetByIdPageQueryHandler(IApplicationDbContext applicationDbContext,IMapper mapper):base(applicationDbContext, mapper)
        {
            
        }

        public async Task<IResultDataControl<ReadPageDto>> Handle(GetByIdPageQuery request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
