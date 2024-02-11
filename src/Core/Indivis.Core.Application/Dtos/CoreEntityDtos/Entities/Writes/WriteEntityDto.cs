using Indivis.Core.Application.Common.BaseClasses.Dtos.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Dtos.CoreEntityDtos.Entity.Writes
{
    public partial class WriteEntityDto : BaseWriteEntityDto
    {
        public string TypeName { get; set; }
        public bool IsUrlData { get; set; }
        public string EntityDefaultProperty { get; set; }
    }
}
