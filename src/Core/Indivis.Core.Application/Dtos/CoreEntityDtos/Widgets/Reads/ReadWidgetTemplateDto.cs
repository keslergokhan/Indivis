using Indivis.Core.Application.Attributes.Systems;
using Indivis.Core.Application.Interfaces.Dtos;
using Indivis.Core.Domain.Commons.CoreEntities;
using Indivis.Core.Domain.Entities.CoreEntities.Widgets;
using Indivis.Core.Domain.Interfaces.Entities.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Dtos.CoreEntityDtos.Widgets.Reads
{
    [CreateMap(typeof(WidgetTemplate))]
    public partial class ReadWidgetTemplateDto : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Template { get; set; }
        public string TemplateFileName
        {
            get
            {
                return Path.GetFileNameWithoutExtension(this.Template);
            }
        }
        public bool IsDefault { get; set; }
        public bool HasStyle { get; set; }
        public bool HasScript { get; set; }
    }

    public partial class ReadWidgetTemplateDto : IEntityImageDto
    {
        public string Image { get; set; }
    }

    public partial class ReadWidgetTemplateDto : IEntityLanguageDto
    {
        public Guid LanguageId { get; set; }
    }

    public partial class ReadWidgetTemplateDto
    {
        public ReadWidgetDto Widget { get; set; }
        public Guid WidgetId { get; set; }
        public ReadWidgetServiceDto WidgetService { get; set; }
        public Guid WidgetServiceId { get; set; }
    }
}
