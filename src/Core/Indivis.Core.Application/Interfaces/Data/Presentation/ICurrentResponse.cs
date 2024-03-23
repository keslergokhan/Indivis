using Indivis.Core.Application.Dtos.CoreEntityDtos.Pages.Reads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Core.Application.Interfaces.Data.Presentation
{
	public interface ICurrentResponse
	{
        public ReadPageDto CurrentPage { get; set; }
    }
}
