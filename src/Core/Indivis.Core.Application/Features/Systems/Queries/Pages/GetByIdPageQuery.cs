using AutoMapper;
using Indivis.Core.Application.Common.BaseClasses.Features.Queries;
using Indivis.Core.Application.Common.Data;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Pages.Reads;
using Indivis.Core.Application.Interfaces.Features.Systems;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Domain.Entities.CoreEntities;
using MediatR;

namespace Indivis.Core.Application.Features.Systems.Queries.Pages
{
    public class GetByIdPageQuery :
        BaseGetByIdEntityDataQuery<Page, ReadPageDto>,
        IRequest<IResultDataControl<ReadPageDto>>,
        IGetByIdEntityRequest<Page>
    {
    }

    public class GetByIdPageQueryHandler : BaseGetByIdEntityDataHandlerQuery<Page, ReadPageDto>, IRequestHandler<GetByIdPageQuery, IResultDataControl<ReadPageDto>>
    {

        public GetByIdPageQueryHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }
        public async Task<IResultDataControl<ReadPageDto>> Handle(GetByIdPageQuery request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
