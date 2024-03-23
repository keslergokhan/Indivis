using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Exceptions.Systems
{
	public class RequestNotFoundPageException : Exception
	{
        public string Url { get; set; }
		public override string Message => "Url adresine bağlı sayfa bulunamadı, lütfen adresi kontrol ediniz !";

		public RequestNotFoundPageException(string url)
		{
			Url = url;
		}

		public RequestNotFoundPageException()
        {

        }

    }
}
