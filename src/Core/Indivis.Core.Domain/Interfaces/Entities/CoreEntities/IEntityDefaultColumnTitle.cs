using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Domain.Interfaces.Entities.CoreEntities
{
    /// <summary>
    /// Tabloda varsayılan tablo değeri, tablonun en temel kolon değeridir.<br></br>
    /// Örnekler :<br></br>
    /// Duyurular:Başlık
    /// Şehirler:Başlık
    /// vs 
    /// </summary>
    public interface IEntityDefaultColumnTitle
    {
        public string Title { get; set; }
    }
}
