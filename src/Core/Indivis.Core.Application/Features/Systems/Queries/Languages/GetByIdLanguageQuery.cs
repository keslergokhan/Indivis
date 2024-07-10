using Indivis.Core.Application.Common.BaseClasses.Features.Queries;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Language.Reads;
using Indivis.Core.Application.Interfaces.Features.FeatureFactories;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Domain.Entities.CoreEntities;
using MediatR;


namespace Indivis.Core.Application.Features.Systems.Queries.Languages
{
    public class GetByIdLanguageQuery :
        BaseGetByIdEntityDataQuery<Language, ReadLanguageDto>,
        IRequest<IResultDataControl<ReadLanguageDto>>,
        IFeatureQueryFactory<GetByIdLanguageQuery>
    {

    }

    public class GetByIdLanguageQueryHandler : BaseGetByIdEntityDataHandlerQuery<Language, ReadLanguageDto>, IRequestHandler<GetByIdLanguageQuery, IResultDataControl<ReadLanguageDto>>
    {

        public GetByIdLanguageQueryHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        public async Task<IResultDataControl<ReadLanguageDto>> Handle(GetByIdLanguageQuery request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
