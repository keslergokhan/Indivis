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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Features.Pages.Queries
{
    public class GetPageSystemsAndPageQuery : 
        IRequest<IResultDataControl<List<ReadPageSystemDto>>>,
        IQueryFactory<GetPageSystemsAndPageQuery>
    {
        public bool OnlineAndOffline { get;set; }
        public StateEnum State { get; set; }
    }


    public class GetPageSystemsAndPageHandler : IRequestHandler<GetPageSystemsAndPageQuery, IResultDataControl<List<ReadPageSystemDto>>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public GetPageSystemsAndPageHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<IResultDataControl<List<ReadPageSystemDto>>> Handle(GetPageSystemsAndPageQuery request, CancellationToken cancellationToken)
        {
            IResultDataControl<List<ReadPageSystemDto>> model = new ResultDataControl<List<ReadPageSystemDto>>();

            try
            {
                IQueryable<PageSystem> query = this._applicationDbContext.PageSystems.Include(x => x.Pages)
                    .ThenInclude(x=>x.Url).AsQueryable();


                if (request.OnlineAndOffline)
                {
                    query = query.Where(x => x.State == (int)StateEnum.Online || x.State == (int)StateEnum.Offline);
                }
                else
                {
                    query = query.Where(x => x.State == (int)request.State);
                }

                List<PageSystem> result = await query.ToListAsync();

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
