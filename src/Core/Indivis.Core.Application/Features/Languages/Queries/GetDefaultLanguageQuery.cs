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

namespace Indivis.Core.Application.Features.Languages.Queries
{
    public class GetDefaultLanguageQuery : IRequest<IResultDataControl<ReadLanguageDto>>
    {
    }

    public class GetDefaultLanguageHandler : IRequestHandler<GetDefaultLanguageQuery, IResultDataControl<ReadLanguageDto>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;

        public GetDefaultLanguageHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IResultDataControl<ReadLanguageDto>> Handle(GetDefaultLanguageQuery request, CancellationToken cancellationToken)
        {
            IResultDataControl<ReadLanguageDto> model = new ResultDataControl<ReadLanguageDto>();

            try
            {
                Language defaultLanguage = await this._dbContext.Languages.OrderBy(x => x.Sort).FirstOrDefaultAsync();
                model.SuccessSetData(this._mapper.Map<ReadLanguageDto>(defaultLanguage));

            }
            catch (Exception ex)
            {
                model.Fail(ex);
            }

            return model;
        }
    }
}
