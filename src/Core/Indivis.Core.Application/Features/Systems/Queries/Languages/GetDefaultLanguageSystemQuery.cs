using AutoMapper;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Language.Reads;
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

namespace Indivis.Core.Application.Features.Systems.Queries.Languages
{
    public class GetDefaultLanguageSystemQuery : IRequest<IResultDataControl<ReadLanguageDto>>
    {
    }

    public class GetDefaultLanguageSystemQueryHandler : IRequestHandler<GetDefaultLanguageSystemQuery, IResultDataControl<ReadLanguageDto>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;

        public GetDefaultLanguageSystemQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IResultDataControl<ReadLanguageDto>> Handle(GetDefaultLanguageSystemQuery request, CancellationToken cancellationToken)
        {
            IResultDataControl<ReadLanguageDto> model = new ResultDataControl<ReadLanguageDto>();

            try
            {
                Language defaultLanguage = await _dbContext.Languages.OrderBy(x => x.Sort).AsNoTracking().FirstOrDefaultAsync();
                model.SuccessSetData(_mapper.Map<ReadLanguageDto>(defaultLanguage));

            }
            catch (Exception ex)
            {
                model.Fail(ex);
            }

            return model;
        }
    }
}
