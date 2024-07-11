﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Interfaces.Features.FeatureFactories
{
    public interface IQueryFactory<TQuery> 
        where TQuery : class, IBaseRequest,new()
    {

    }
}
