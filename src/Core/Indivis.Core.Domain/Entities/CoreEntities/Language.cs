﻿using Indivis.Core.Domain.Commons.CoreEntities;
using Indivis.Core.Domain.Interfaces.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Domain.Entities.CoreEntities
{
    public class Language : BaseEntity
    {
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string Culture { get; set; }
        public string FLag { get; set; }
        public byte Sort { get; set; }
        public string Currency { get; set; }

    }
}
