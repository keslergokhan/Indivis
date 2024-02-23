using Indivis.Core.Application.Common.SystemInitializers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            services.AddAssemblySystemEntityFeatures(Assembly.GetExecutingAssembly());
            services.AddAssemblyFeatureQueryFactory(Assembly.GetExecutingAssembly());


			return services;
        }
    }
}
