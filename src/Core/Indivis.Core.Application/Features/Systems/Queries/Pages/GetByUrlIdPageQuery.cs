﻿using AutoMapper;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Pages.Reads;
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

namespace Indivis.Core.Application.Features.Systems.Queries.Pages
{
    public class GetByUrlIdPageQuery: 
        IRequest<IResultDataControl<ReadPageDto>>,
        IFeatureQueryFactory<GetByUrlIdPageQuery>
    {
        public Guid UrlId { get; set; }
        public StateEnum State { get; set; }
    }

    public class GetByUrlIdPageQueryHandler : IRequestHandler<GetByUrlIdPageQuery, IResultDataControl<ReadPageDto>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper mapper;

        public GetByUrlIdPageQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            this.mapper = mapper;
        }

        public async Task<IResultDataControl<ReadPageDto>> Handle(GetByUrlIdPageQuery request, CancellationToken cancellationToken)
        {
            IResultDataControl<ReadPageDto> model = new ResultDataControl<ReadPageDto>();

            Page page = await this._applicationDbContext
                .Pages
                .Include(x=>x.PageSystem)
                .FirstOrDefaultAsync(x => x.UrlId == request.UrlId);

            model.SetData(this.mapper.Map<ReadPageDto>(page));
            return model;
        }
    }

}
