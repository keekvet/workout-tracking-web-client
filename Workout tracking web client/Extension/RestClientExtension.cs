using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workout_tracking_web_client.Exceptions;

namespace Workout_tracking_web_client.Extension
{
    public static class RestClientExtension
    {
        public static async Task<IRestResponse<T>> ExecuteWithTimeoutExceptionAsync<T>(
            this RestClient client, 
            RestRequest request)
        {
            IRestResponse<T> response =
                await client.ExecuteAsync<T>(request);

            if (!response.IsSuccessful)
                throw new ApiConnectionException();

            return response;
        }
    }
}
