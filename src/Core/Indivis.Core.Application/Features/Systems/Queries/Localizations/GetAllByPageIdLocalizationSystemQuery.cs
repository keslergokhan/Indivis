using AutoMapper;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Localization.Reads;
using Indivis.Core.Application.Enums.Systems;
using Indivis.Core.Application.Interfaces.Data;
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

namespace Indivis.Core.Application.Features.Systems.Queries.Localizations
{
    public class GetAllByPageIdLocalizationSystemQuery : IRequest<IResultDataControl<List<ReadLocalizationDto>>>
    {
        public Guid PageId { get; set; }
    }

    public class GetAllByPageIdLocalizationSystemQueryHandler :
        IRequestHandler<GetAllByPageIdLocalizationSystemQuery, IResultDataControl<List<ReadLocalizationDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _applicationDbContext;

        public GetAllByPageIdLocalizationSystemQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<IResultDataControl<List<ReadLocalizationDto>>> Handle(GetAllByPageIdLocalizationSystemQuery request, CancellationToken cancellationToken)
        {
            IResultDataControl<List<ReadLocalizationDto>> model = new ResultDataControl<List<ReadLocalizationDto>>();

            try
            {
                List<Localization> localizationList = await this._applicationDbContext.Localization
                    .Where(x => x.PageId == request.PageId && x.State == (int)StateEnum.Online)
                    .Include(x => x.Region.Where(i => i.State == (int)StateEnum.Online))
                    .ToListAsync();

                model.SuccessSetData(this._mapper.Map<List<ReadLocalizationDto>>(localizationList));
            }
            catch (Exception ex)
            {
                model.Fail(ex);
            }

            return model;
        }
    }
}
