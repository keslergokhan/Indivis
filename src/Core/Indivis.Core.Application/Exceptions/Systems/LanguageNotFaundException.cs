using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Exceptions.Systems
{
    public class LanguageNotFaundException : Exception
    {
        public override string Message => "Language verisine ulaşılamadı !";
        public LanguageNotFaundException()
        {
        }
    }
}
