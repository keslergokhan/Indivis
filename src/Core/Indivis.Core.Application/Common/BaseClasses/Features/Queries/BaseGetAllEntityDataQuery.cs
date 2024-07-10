using AutoMapper;
using Indivis.Core.Application.Common.BaseClasses.Dtos.CoreEntities;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Pages.Reads;
using Indivis.Core.Application.Enums.Systems;
using Indivis.Core.Application.Interfaces.Data;
using Indivis.Core.Application.Interfaces.Results;
using Indivis.Core.Application.Results;
using Indivis.Core.Domain.Entities.CoreEntities;
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
    public interface BaseGetAllEntityDataQuery
    {
        public bool OnlineAndOffline { get ; set; } 
        public StateEnum Status { get; set; }
    }


    public class BaseGetAllEntityDataQuery<TEntity, TResult>
        : BaseGetAllEntityDataQuery,
        IRequest<IResultDataControl<List<TResult>>>
    {
        public StateEnum Status { get; set; }
        private bool _onlineAndOffline = false;
        public bool OnlineAndOffline { get { return this._onlineAndOffline; } set { this._onlineAndOffline = value; } }
    }


    public abstract class BaseGetAllEntityDataHandler<TEntity, TResult>
        : IRequestHandler<BaseGetAllEntityDataQuery<TEntity, TResult>, IResultDataControl<List<TResult>>>
        where TResult : BaseReadEntityDto, new()
        where TEntity : class, IEntity
    {

        protected readonly IMapper _mapper;
        protected readonly IApplicationDbContext _applicationDbContext;
        private readonly IServiceProvider _serviceProvider;

        public BaseGetAllEntityDataHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _applicationDbContext = serviceProvider.GetService<IApplicationDbContext>();
            _mapper = serviceProvider.GetService<IMapper>();
        }

        public async Task<IResultDataControl<List<TResult>>> Handle(BaseGetAllEntityDataQuery<TEntity, TResult> request, CancellationToken cancellationToken)
        {
            IResultDataControl<List<TResult>> outModel = new ResultDataControl<List<TResult>>();
            try
            {
                IQueryable<TEntity> query = this._applicationDbContext.Set<TEntity>().AsQueryable();
                
                if (request.OnlineAndOffline)
                {
                    query = query.Where(x => x.State == (int)StateEnum.Online || x.State == (int)StateEnum.Offline).AsQueryable();
                }
                else
                {
                    query = query.Where(x => x.State == (int)request.Status).AsQueryable();
                }

                List<TEntity> result = await query.ToListAsync();
                outModel.SuccessSetData(this._mapper.Map<List<TResult>>(result));
            }
            catch (Exception ex)
            {
                outModel.Fail(ex);
            }

            return outModel;
        }
    }
   
}
