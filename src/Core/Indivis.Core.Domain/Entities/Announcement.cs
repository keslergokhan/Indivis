﻿using Indivis.Core.Domain.Commons.CoreEntities;
using Indivis.Core.Domain.Entities.CoreEntities;
using Indivis.Core.Domain.Interfaces.Entities;
using Indivis.Core.Domain.Interfaces.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Domain.Entities
{
    public partial class Announcement : BaseEntity
    {

    }

    public partial class Announcement : BaseEntity, IEntityLanguage
    {
        public Guid LanguageId { get; set; }
    }

    public partial class Announcement : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public partial class Announcement : IEntityUrl
    {
        public Guid UrlId { get; set; }
        public Url Url { get; set; }
    }

    public partial class Announcement : IEntitySeo
    {
        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public string SeoBreadcrumbTitle { get; set; }
    }

    public partial class Announcement : IEntitySitemap
    {
        public bool sitemapNoIndex { get; set; }
        public bool SitemapNoWrite { get; set; }
    }
}
