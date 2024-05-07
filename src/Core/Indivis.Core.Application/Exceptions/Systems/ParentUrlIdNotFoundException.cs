using Indivis.Presentation.WebUI.System.Interfaces.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Exceptions.Systems
{
    public class ParentUrlIdNotFoundException : Exception
    {
        public ParentUrlIdNotFoundException() : base("UrlParentId değeri boş olamaz !")
        {

        }

        public ParentUrlIdNotFoundException(IUrlSystemType urlSystemType) : base($"UrlParentId değeri boş olamaz ! \n {urlSystemType.GetType().Name} yapısı olan Url kayıtlarının Page tablosunda karşılığı bulunmamaktadır, bu nedenle base bir detail url kaydı ve bu kaydı ParentUrlId değerinde tutulması gerekmektedir.")
        {

        }
    }
}
