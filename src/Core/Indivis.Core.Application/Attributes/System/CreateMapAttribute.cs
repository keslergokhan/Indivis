using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Attributes.System
{
    
    [AttributeUsage(AttributeTargets.Class)]
    public class CreateMapAttribute : Attribute
    {
        public Type[] DestinationTypes { get; set; }
        public CreateMapAttribute(params Type[] DestinationTypes)
        {
            this.DestinationTypes = DestinationTypes;
        }
    }
}
