using Indivis.Core.Application.Common.SystemInitializers;
using Indivis.Core.Application.Features.Systems.Queries;
using Indivis.Core.Application.Interfaces.Features.Systems;
using Indivis.Core.Domain.Entities.CoreEntities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Serilog;
using System.Reflection;


namespace Indivis.Core.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
              .CreateLogger();
            services.AddLogging(x =>
            {
                x.AddSerilog(logger, dispose: true);
            });


            services.AddMediatR(x=>x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddSystemMapper(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddSystemCoreEntityFeatures(Assembly.GetExecutingAssembly());
           

            return services;
        }
    }
}
