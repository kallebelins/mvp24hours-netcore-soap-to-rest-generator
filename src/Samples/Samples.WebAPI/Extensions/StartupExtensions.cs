//=====================================================================================
// Developed by Kallebe Lins (kallebe.santos@outlook.com)
// Teacher, Architect, Consultant and Project Leader
// Virtual Card: https://www.linkedin.com/in/kallebelins
//=====================================================================================
// Reproduction or sharing is free! Contribute to a better world!
//=====================================================================================
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mvp24Hours.Infrastructure.Extensions;
using Mvp24Hours.WebAPI.Extensions;
using Samples.WebAPI.WebService;

namespace Samples.WebAPI.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class StartupExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddMyServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Mvp24Hours.Infrastructure
            services.AddMvp24HoursLogging(); // logging
            services.AddMvp24HoursNotification(); //  notification

            // Mvp24Hours.WebAPI
            services.AddMvp24HoursService(); // filters /  context
            services.AddMvp24HoursZipService(); // compression
            services.AddMvp24HoursJson(); // json
            services.AddMvp24HoursSwagger("Samples API", xmlCommentsFileName: "Samples.WebAPI.xml"); // swagger

            // service client
            services.AddSingleton(
                new WebService1SoapClient(
                    WebService1SoapClient.EndpointConfiguration.WebService1Soap12, configuration.GetSection("Settings:ServiceUrl")?.Value
                )
            );

            return services;
        }
    }
}
