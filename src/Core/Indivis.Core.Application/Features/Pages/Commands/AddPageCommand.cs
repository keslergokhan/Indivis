using AutoMapper;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Pages.Reads;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Pages.Writes;
using Indivis.Core.Application.Interfaces.Data;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Application.Results;
using Indivis.Core.Domain.Entities.CoreEntities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Features.Pages.Commands
{
    public class AddPageCommand : IRequest<IResultDataControl<ReadPageDto>>
    {
        public WritePageDto Page { get; set; }
    }

    public class AddPageCommandHandler : IRequestHandler<AddPageCommand, IResultDataControl<ReadPageDto>>
    {

        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public AddPageCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper = null)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<IResultDataControl<ReadPageDto>> Handle(AddPageCommand request, CancellationToken cancellationToken)
        {
            IResultDataControl<ReadPageDto> model = new ResultDataControl<ReadPageDto>();

            try
            {
                Page page = this._mapper.Map<Page>(request.Page);
                page.Id = Guid.NewGuid();
                EntityEntry<Page> addPageEntry = await this._applicationDbContext.Pages.AddAsync(page);


                int result = await this._applicationDbContext.SaveChangesAsync(new CancellationToken());

                if (result > 1)
                {
                    Page resultPage = await this._applicationDbContext.Pages.FirstOrDefaultAsync(x => x.Id == page.Id);
                    model.SuccessSetData(this._mapper.Map<ReadPageDto>(resultPage));
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
