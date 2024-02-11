using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Common.BaseClasses.Dtos.CoreEntities;
using Indivis.Core.Domain.Entities.CoreEntities;

namespace Indivis.Core.Application.Dtos.CoreEntityDtos.Entities.Reads
{
    [CreateMap(typeof(Indivis.Core.Domain.Entities.CoreEntities.Entity))]
    public partial class ReadEntityDto : BaseReadEntityDto
    {
        public string TypeName { get; set; }
        public bool IsUrlData { get; set; }
        public string EntityDefaultProperty { get; set; }
    }
}
