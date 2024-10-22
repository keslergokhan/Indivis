using AutoMapper;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Localization.Reads;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Localization.Writes;
using Indivis.Core.Application.Enums.Systems;
using Indivis.Core.Application.Interfaces.Data;
using Indivis.Core.Application.Interfaces.Features;
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

namespace Indivis.Core.Application.Features.Systems.Commands.Localizations
{
    public class AddLocalizationRegionSystemCommand: 
        IRequest<IResultDataControl<ReadLocalizationDto>>,
        ILanguageFilterQuery
    {
        public WriteLocalizationRegionDto LocalizationRegion { get; set; }
        public Guid LanguageId { get; set; }
    }

    public class AddLocalizationRegionLocalizationSystemHandlerCommand : IRequestHandler<AddLocalizationRegionSystemCommand, IResultDataControl<ReadLocalizationDto>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public AddLocalizationRegionLocalizationSystemHandlerCommand(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<IResultDataControl<ReadLocalizationDto>> Handle(AddLocalizationRegionSystemCommand request, CancellationToken cancellationToken)
        {
            IResultDataControl<ReadLocalizationDto> model = new ResultDataControl<ReadLocalizationDto>();

            try
            {
                Localization loc = await this._applicationDbContext.Localization.Include(x=>x.Region).FirstOrDefaultAsync(x => x.Id == request.LocalizationRegion.LocalizationId);

                if (loc.Region.Any())
                {
                    LocalizationRegion localizationRegion = loc.Region.FirstOrDefault(x => x.LanguageId == request.LanguageId);
                    localizationRegion.Value = request.LocalizationRegion.Value;
                    localizationRegion.ModifiedDate = DateTime.Now;

                }
                else
                {
                    loc.Region = new List<LocalizationRegion>();
                    loc.Region.Add(this._mapper.Map<LocalizationRegion>(request.LocalizationRegion));
                }

               

                int save = await this._applicationDbContext.SaveChangesAsync();
                if (save > 0)
                {
                    model.SuccessSetData(this._mapper.Map<ReadLocalizationDto>(loc));
                }
                else
                {
                    model.Fail();
                }
            }
            catch (Exception ex)
            {
                model.Fail(ex);
            }

            return model;
        }
    }

}
