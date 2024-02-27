using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Exceptions.Systems
{
    public class InterfaceNotFoundException : Exception
    {
        public string Message { get; set; }
        public InterfaceNotFoundException()
        {
            this.Message = "Interface bulunamadı !";
        }
        public InterfaceNotFoundException(string className, string interfaceName)
        {
            this.Message = $"{className} içerisinde {interfaceName} bulunamadı !";
        }
    }
}
