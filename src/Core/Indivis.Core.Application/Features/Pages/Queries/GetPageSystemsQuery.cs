using AutoMapper;
using Indivis.Core.Application.Dtos.CoreEntityDtos.PageSystems.Reads;
using Indivis.Core.Application.Enums.Systems;
using Indivis.Core.Application.Interfaces.Data;
using Indivis.Core.Application.Interfaces.Features.FeatureFactories;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Application.Results;
using Indivis.Core.Domain.Entities.CoreEntities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Features.Pages.Queries
{
    public class GetPageSystemsQuery : 
        IQueryFactory<GetPageSystemsQuery>,
        IRequest<IResultDataControl<List<ReadPageSystemDto>>>
    {

        public StateEnum? Status { get; set; }
    }


    public class GetPageSystemsQueryHandler : IRequestHandler<GetPageSystemsQuery, IResultDataControl<List<ReadPageSystemDto>>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public GetPageSystemsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<IResultDataControl<List<ReadPageSystemDto>>> Handle(GetPageSystemsQuery request, CancellationToken cancellationToken)
        {
            IResultDataControl<List<ReadPageSystemDto>> model = new ResultDataControl<List<ReadPageSystemDto>>();

            try
            {
                List<PageSystem> result = await this._applicationDbContext.PageSystems.AsNoTracking().Where(x => x.State == (int)request.Status).ToListAsync();

                model.SuccessSetData(this._mapper.Map<List<ReadPageSystemDto>>(result));
            }
            catch (Exception ex)
            {
                model.Fail(ex);
            }

            return model;
        }
    }
}
