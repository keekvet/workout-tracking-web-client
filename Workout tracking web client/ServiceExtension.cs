using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workout_tracking_web_client.Configurations;
using Workout_tracking_web_client.Services.Implementations;
using Workout_tracking_web_client.Services.Interfaces;

namespace Workout_tracking_web_client
{
    public static class ServiceExtention
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpClientService, HttpClientService>();

            return services;
        }

        public static IServiceCollection AddConfigurations(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.Configure<ConnectionStringsConfiguration>(configuration.GetSection("ConnectionStrings"));

            return services;
        }
    }
}
