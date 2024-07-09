using Indivis.Core.Application.Common.BaseClasses.Features.Queries;
using Indivis.Core.Application.Dtos.CoreEntityDtos.PageSystems.Reads;
using Indivis.Core.Application.Interfaces.Features.Systems;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Domain.Entities.CoreEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Features.Systems.Queries.Pages
{
    public class GetAllPageSystemsQuery : 
        BaseGetAllEntityDataQuery<PageSystem,ReadPageSystemDto>,
        IRequest<IResultDataControl<List<ReadPageSystemDto>>>,
        IGetAllEntityRequest<PageSystem>

    {

    }


    public class GetAllPageSystemsHandler : 
        BaseGetAllEntityDataHandler<PageSystem, ReadPageSystemDto>,
        IRequestHandler<GetAllPageSystemsQuery,IResultDataControl<List<ReadPageSystemDto>>>

        
    {
        public GetAllPageSystemsHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<IResultDataControl<List<ReadPageSystemDto>>> Handle(GetAllPageSystemsQuery request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
