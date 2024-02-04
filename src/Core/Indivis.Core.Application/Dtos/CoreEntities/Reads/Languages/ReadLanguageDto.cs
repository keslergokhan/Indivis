using Indivis.Core.Application.Commons.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Dtos.CoreEntities.Reads.Languages
{
    public class ReadLanguageDto : BaseReadEntityDto
    {
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string Culture { get; set; }
        public string FLag { get; set; }
        public byte Sort { get; set; }
        public string Currency { get; set; }
    }
}
