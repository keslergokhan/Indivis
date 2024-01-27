using Indivis.Infrastructure.Persistence.EntityFramework.IndivisContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indivis.Infrastructure.Persistence
{
    public static class ServiceRegistrations
    {
        public static void AddPersistence(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<IndivisContext>(x=>x.UseSqlServer(configuration.GetConnectionString("default")));
        }
    }
}
