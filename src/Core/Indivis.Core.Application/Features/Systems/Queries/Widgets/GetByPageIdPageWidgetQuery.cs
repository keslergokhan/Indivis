using Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads;
using Indivis.Core.Application.Interfaces.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Features.Systems.Queries.Widgets
{
    public class GetByPageIdPageWidgetQuery : IRequest<IResultDataControl<ReadPageWidgetDto>>
    {
        public Guid PageId { get; set; }
    }
}
