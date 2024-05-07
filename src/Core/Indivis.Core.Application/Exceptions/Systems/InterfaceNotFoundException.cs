using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Exceptions.Systems
{
    public class InterfaceNotFoundException : Exception
    {
        public InterfaceNotFoundException():base("Interface bulunamadı !")
        {

        }
        public InterfaceNotFoundException(string className, string interfaceName):base($"{className} içerisinde {interfaceName} bulunamadı !")
        {
        }
    }
}
