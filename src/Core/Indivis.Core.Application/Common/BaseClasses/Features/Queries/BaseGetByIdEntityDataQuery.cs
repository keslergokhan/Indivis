using AutoMapper;
using Indivis.Core.Application.Common.BaseClasses.Dtos.CoreEntities;
using Indivis.Core.Application.Interfaces.Data;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Application.Results;
using Indivis.Core.Domain.Interfaces.Entities.CoreEntities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Common.BaseClasses.Features.Queries
{
    public interface BaseGetByIdEntityDataQuery
    {
        public Guid Id { get; set; }
    }
    public class BaseGetByIdEntityDataQuery<TEntity, TResult> : BaseGetByIdEntityDataQuery, IRequest<IResultDataControl<TResult>>
    {
        public Guid Id { get; set; }
    }

    public abstract class BaseGetByIdEntityDataHandlerQuery<TEntity, TResult> : 
        IRequestHandler<BaseGetByIdEntityDataQuery<TEntity, TResult>, IResultDataControl<TResult>>
        where TResult : BaseReadEntityDto, new()
        where TEntity : class, IEntity
    {


        protected readonly IMapper _mapper;
        protected readonly IApplicationDbContext _applicationDbContext;
        private readonly IServiceProvider _serviceProvider;

        public BaseGetByIdEntityDataHandlerQuery(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _applicationDbContext = serviceProvider.GetService<IApplicationDbContext>();
            _mapper = serviceProvider.GetService<IMapper>();
        }

        public async Task<IResultDataControl<TResult>> Handle(BaseGetByIdEntityDataQuery<TEntity, TResult> request, CancellationToken cancellationToken)
        {
            IResultDataControl<TResult> outModel = new ResultDataControl<TResult>();

            TEntity result = await _applicationDbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == request.Id);

            return outModel.SuccessSetData(new TResult() { Id = request.Id });
        }
    }
}
