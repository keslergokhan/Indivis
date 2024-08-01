using AutoMapper;
using Indivis.Core.Application.Common.BaseClasses.Features.Queries;
using Indivis.Core.Application.Common.Data;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Pages.Reads;
using Indivis.Core.Application.Interfaces.Features.FeatureFactories;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Domain.Entities.CoreEntities;
using MediatR;

namespace Indivis.Core.Application.Features.Systems.Queries.Pages
{
    public class GetPageByIdQuery :
        BaseGetByIdEntityDataQuery<Page, ReadPageDto>,
        IRequest<IResultDataControl<ReadPageDto>>,
        IQueryFactory<GetPageByIdQuery>
    {
    }

    public class GetPageByIdHandler : BaseGetByIdEntityIncludeUrlDataHandlerQuery<Page, ReadPageDto>, IRequestHandler<GetPageByIdQuery, IResultDataControl<ReadPageDto>>
    {

        public GetPageByIdHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }
        public async Task<IResultDataControl<ReadPageDto>> Handle(GetPageByIdQuery request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
