using AutoMapper;
using Indivis.Core.Application.Dtos.CoreEntityDtos.PageSystems.Reads;
using Indivis.Core.Application.Enums.Systems;
using Indivis.Core.Application.Interfaces.Data;
using Indivis.Core.Application.Interfaces.Dtos;
using Indivis.Core.Application.Interfaces.Features;
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
        IQueryFactory<GetPageSystemsAndPageQuery>,
        IEntityLanguageDto,
        IOnlineAndOfflineQuery
    {
        public bool OnlineAndOffline { get;set; }
        public StateEnum State { get; set; }
        public Guid LanguageId { get; set; }
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
                IQueryable<PageSystem> query = this._applicationDbContext.PageSystems.AsNoTracking();
                if (request.OnlineAndOffline == true)
                {
                    query = query.Where(x => x.State == (int)StateEnum.Online || x.State == (int)StateEnum.Offline).AsQueryable();
                }
                else
                {
                    query = query.Where(x => x.State == (int)request.State).AsQueryable();
                }

                query= query
                    .Include(x => x.Pages.Where(x=>x.LanguageId == request.LanguageId))
                    .ThenInclude(x => x.Url)
                    .Include(x=>x.Pages).ThenInclude(x=>x.SubPages).ThenInclude(x=>x.Url)
                    .AsNoTrackingWithIdentityResolution().AsQueryable();



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
