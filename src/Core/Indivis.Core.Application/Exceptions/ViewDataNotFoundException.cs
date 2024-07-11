using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Exceptions
{
    public class ViewDataNotFoundException : Exception
    {
        private string _message;
        public string Message { get { return _message; } }
        public ViewDataNotFoundException()
        {
            this._message = "Sayfa için ihtiyaç duyulan verilere ulaşılamadı !";
        }

        public ViewDataNotFoundException(string dataName)
        {
            this._message = $"Sayfa için ihtiyaç duyulan {dataName}, verilere ulaşılamadı !";
        }


    }
}
