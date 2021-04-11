using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workout_tracking_web_client.Dto;

namespace Workout_tracking_web_client.Extension
{
    public static class HttpResponseExtension
    {
        public static string GetErrorMessage(this IRestResponse response)
        {
            StringBuilder stringBuilder = new StringBuilder(response.Content);

            stringBuilder.Replace("m", "M", 0, 4);
            return SimpleJson.DeserializeObject<ErrorMessageDto>(stringBuilder.ToString()).Message;
        }

    }
}
