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
    public class GetByKeyLocalizationSystemQuery : IRequest<IResultDataControl<ReadLocalizationDto>>
    {
        public string Key { get; set; }
    }

    public class GetByKeyLocalizationSystemQueryHandler :
        IRequestHandler<GetByKeyLocalizationSystemQuery, IResultDataControl<ReadLocalizationDto>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _applicationDbContext;

        public GetByKeyLocalizationSystemQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<IResultDataControl<ReadLocalizationDto>> Handle(GetByKeyLocalizationSystemQuery request, CancellationToken cancellationToken)
        {
            IResultDataControl<ReadLocalizationDto> model = new ResultDataControl<ReadLocalizationDto>();
            try
            {
                Localization localization = await this._applicationDbContext.Localization.AsNoTracking()
                    .Where(x => x.Key == request.Key && x.State == (int)StateEnum.Online)
                    .Include(x => x.Region)
                    .SingleAsync();


                model.SuccessSetData(this._mapper.Map<ReadLocalizationDto>(localization));
            }
            catch (Exception ex)
            {
                model.Fail(ex);
            }

            return model;
        }
    }
}
