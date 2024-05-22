using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Dtos.CoreEntityDtos.EntityUrl.Reads;
using Indivis.Core.Application.Dtos.CoreEntityDtos.Urls.Reads;
using Indivis.Core.Application.Interfaces.Data.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Common.Data.Presentation
{
    [DependencyRegister(typeof(ICurrentRequest),DependencyTypes.Scopet)]
    public class CurrentRequest : ICurrentRequest
    {
        public string Schema {get; set;}
        public string Domain {get; set;}
        public string Region {get; set;}
        public string Path {get; set;}
        public string FullPath {get; set;}
        public string BaseUrl {get; set;}
        public bool EditMode {get; set;}
		public ReadUrlDto CurrentUrl { get; set; }
        public ReadEntityUrlDto CurrentEntityUrl { get; set; }
    }
}
