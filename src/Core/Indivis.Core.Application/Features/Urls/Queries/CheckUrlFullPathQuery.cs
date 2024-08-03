using Azure.Core;
using Indivis.Core.Application.Interfaces.Data;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Application.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Features.Urls.Queries
{
    public class CheckUrlFullPathQuery : IRequest<IResultDataControl<CheckUrlFullPathQueryResult>>
    {
        public string FullPath { get; set; }
    }

    public class CheckUrlFullPathQueryResult
    {
        public bool fullPathFound { get; set; }
    }

    public class CheckUrlFullPathHandlerQuery : IRequestHandler<CheckUrlFullPathQuery, IResultDataControl<CheckUrlFullPathQueryResult>>
    {
        private readonly IApplicationDbContext _pplicationDbContext;

        public CheckUrlFullPathHandlerQuery(IApplicationDbContext pplicationDbContext)
        {
            _pplicationDbContext = pplicationDbContext;
        }

        public async Task<IResultDataControl<CheckUrlFullPathQueryResult>> Handle(CheckUrlFullPathQuery request, CancellationToken cancellationToken)
        {
            IResultDataControl<CheckUrlFullPathQueryResult> model = new ResultDataControl<CheckUrlFullPathQueryResult>();

            try
            {
                bool result = await this._pplicationDbContext.Urls.AnyAsync(x=>x.FullPath == request.FullPath && x.State != (int)EntityState.Deleted);

                model.SetData(new CheckUrlFullPathQueryResult()
                {
                    fullPathFound = result
                });

            }
            catch (Exception ex)
            {
                model.Fail(ex);
            }

            return model;
        }
    }


}
