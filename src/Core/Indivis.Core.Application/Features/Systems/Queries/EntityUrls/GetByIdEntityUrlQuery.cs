using Indivis.Core.Application.Common.BaseClasses.Features.Queries;
using Indivis.Core.Application.Dtos.CoreEntityDtos.EntityUrl.Reads;
using Indivis.Core.Application.Interfaces.Features.Systems;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Domain.Entities.CoreEntities;
using MediatR;

namespace Indivis.Core.Application.Features.Systems.Queries.EntityUrls
{
    public class GetByIdEntityUrlQuery : 
        BaseGetByIdEntityDataQuery<EntityUrl,ReadEntityUrlDto>
        ,IRequest<IResultDataControl<ReadEntityUrlDto>>
        ,IGetByIdEntityRequest<EntityUrl>
    {

    }

	public class GetByIdEntityUrlQueryHandler : 
		BaseGetByIdEntityDataHandlerQuery<EntityUrl, ReadEntityUrlDto>,
		IRequestHandler<GetByIdEntityUrlQuery,IResultDataControl<ReadEntityUrlDto>>
	{
		public GetByIdEntityUrlQueryHandler(IServiceProvider serviceProvider) : base(serviceProvider)
		{
		}

		public async Task<IResultDataControl<ReadEntityUrlDto>> Handle(GetByIdEntityUrlQuery request, CancellationToken cancellationToken)
		{
			return await base.Handle(request,cancellationToken);
		}
	}
}
