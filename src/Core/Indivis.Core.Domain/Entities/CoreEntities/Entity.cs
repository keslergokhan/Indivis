using Indivis.Core.Domain.Commons.CoreEntities;
using Indivis.Core.Domain.Interfaces.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Domain.Entities.CoreEntities
{
    public class Entity : BaseEntity, IEntity
    {
        public string TypeName { get; set; }
        /// <summary>
        /// Entity url bilgileri taşıyor mu
        /// Örnek:Announcement entity yapısı aynı zamanda bir detay sayfasının verilerini barındırdığı için
        /// Announcement içerisinde Url entitiysi bulunmaktadır.
        /// </summary>
        public bool IsUrlData { get; set; }

    }
}
