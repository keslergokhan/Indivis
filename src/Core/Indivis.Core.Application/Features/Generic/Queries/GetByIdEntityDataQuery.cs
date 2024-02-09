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
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Features.Generic.Queries
{
    public abstract class GetByIdEntityDataQuery<TEntity,TResult> : IRequest<IResultDataControl<TResult>>
    {
        public Guid Id { get; set; }
    }

    public class GetByIdEntityDataHandlerQuery<TEntity, TResult> : IRequestHandler<GetByIdEntityDataQuery<TEntity, TResult>, IResultDataControl<TResult>>
        where TResult : BaseReadEntityDto, new()
        where TEntity : class,IEntity
    {


        protected readonly IMapper _mapper;
        protected readonly IApplicationDbContext _applicationDbContext;
        private readonly IServiceProvider _serviceProvider;

        public GetByIdEntityDataHandlerQuery(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
            this._applicationDbContext = serviceProvider.GetService<IApplicationDbContext>();
            this._mapper = serviceProvider.GetService<IMapper>();
        }

        public async Task<IResultDataControl<TResult>> Handle(GetByIdEntityDataQuery<TEntity, TResult> request, CancellationToken cancellationToken)
        {
            IResultDataControl<TResult> outModel = new ResultDataControl<TResult>();

            TEntity result = await this._applicationDbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == request.Id);


            var sss = this._mapper.Map<TResult>(result);

            return outModel.SuccessSetData(new TResult() { Id = request.Id });
        }
    }
}
