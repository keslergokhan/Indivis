using Indivis.Core.Application.Dtos.CoreEntityDtos.PageSystems.Reads;
using Indivis.Core.Application.Enums.Systems;
using Indivis.Core.Application.Interfaces.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Features.Pages.Queries
{
    public class GetPageCategoriesQuery : IRequest<IResultDataControl<ReadPageSystemDto>>
    {
        public StateEnum Status { get; set; }
    }


    public class GetPageCategoriesHandler : IRequestHandler<GetPageCategoriesQuery, IResultDataControl<ReadPageSystemDto>>
    {
        public async Task<IResultDataControl<ReadPageSystemDto>> Handle(GetPageCategoriesQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
