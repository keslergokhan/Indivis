using Indivis.Core.Application.Dtos.CoreEntityDtos.Urls.Reads;
using Indivis.Core.Application.Interfaces.Features.FeatureFactories;
using Indivis.Core.Application.Interfaces.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Features.Urls.Queries
{
    public class GetByFullPathUrlQuery : 
        IRequest<IResultDataControl<ReadUrlDto>>,
        IFeatureQueryFactory<GetByFullPathUrlQuery>
    {
        public string FullPath { get; set; }
    }
}
