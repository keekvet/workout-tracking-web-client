using Microsoft.Extensions.Options;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workout_tracking_web_client.Configurations;
using Workout_tracking_web_client.Services.Interfaces;

namespace Workout_tracking_web_client.Services.Implementations
{
    public class HttpClientService : IHttpClientService
    {
        IOptions<ConnectionStringsConfiguration> connectionStringsConfiguration;

        public HttpClientService(IOptions<ConnectionStringsConfiguration> connectionStringsConfiguration)
        {
            this.connectionStringsConfiguration = connectionStringsConfiguration;
        }

        public RestClient NewInstance(string jwtToken)
        {
            RestClient client = new RestClient(connectionStringsConfiguration.Value.ApiServer);
            client.Authenticator = new JwtAuthenticator(jwtToken);
            
            return client;
        }
    }
}
