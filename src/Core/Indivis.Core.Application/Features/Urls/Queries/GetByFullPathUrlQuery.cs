﻿using AutoMapper;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Urls.Reads;
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

namespace Indivis.Core.Application.Features.Urls.Queries
{
    public class GetByFullPathUrlQuery : 
        IRequest<IResultDataControl<ReadUrlDto>>,
        IQueryFactory<GetByFullPathUrlQuery>
    {
        public string FullPath { get; set; }
        public StateEnum State { get; set; }
    }


    public class GetByFullPathUrlQueryHandler : IRequestHandler<GetByFullPathUrlQuery, IResultDataControl<ReadUrlDto>>
    {
        private readonly IApplicationDbContext _applicaitonDbContext;
        private readonly IMapper _mapper;

        public GetByFullPathUrlQueryHandler(IApplicationDbContext applicaitonDbContext, IMapper mapper)
        {
            _applicaitonDbContext = applicaitonDbContext;
            _mapper = mapper;
        }

        public async Task<IResultDataControl<ReadUrlDto>> Handle(GetByFullPathUrlQuery request, CancellationToken cancellationToken)
        {
            IResultDataControl<ReadUrlDto> model = new ResultDataControl<ReadUrlDto>();

            Url firstUrl = this._applicaitonDbContext.Urls
                .Include(x=>x.ParentUrl)
                .Include(x=>x.Language)
                .Include(x=>x.UrlSystemType)
                .FirstOrDefault(x => x.FullPath == request.FullPath && x.IsEntity == false);

            if (firstUrl==null)
            {
                model.Fail();
                return model;
            }

            model.SuccessSetData(this._mapper.Map<ReadUrlDto>(firstUrl));
            return model;
        }
    }
}
