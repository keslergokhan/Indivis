using AutoMapper;
using Indivis.Core.Application.Common.Data;
using Indivis.Core.Application.Common.Dtos.CoreEntities;
using Indivis.Core.Application.Features.Pages.Queries;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Application.Results;
using Indivis.Core.Domain.Commons.CoreEntities;
using Indivis.Core.Domain.Interfaces.Entities.CoreEntities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Features.Generic.Queries
{
    public abstract class GetByIdEntityDataQuery<T,TResult> : IRequest<IResultDataControl<TResult>>
    {
        public Guid Id { get; set; }
    }

    public class GetByIdEntityDataHandlerQuery<T,TResult> : IRequestHandler<GetByIdEntityDataQuery<T,TResult>, IResultDataControl<TResult>>
        where TResult : BaseReadEntityDto, new()
        where T : class,IEntity
    {
        protected IMapper _mapper;
        protected IApplicationDbContext _applicationDbContext;

        public GetByIdEntityDataHandlerQuery(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            this._applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<IResultDataControl<TResult>> Handle(GetByIdEntityDataQuery<T,TResult> request, CancellationToken cancellationToken)
        {
            IResultDataControl<TResult> outModel = new ResultDataControl<TResult>();

            T result = await this._applicationDbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == request.Id);


            var sss = this._mapper.Map<TResult>(result);

            return outModel.SuccessSetData(new TResult() { Id = request.Id });
        }
    }
}
