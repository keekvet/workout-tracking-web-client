using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workout_tracking_web_client.Services.Interfaces
{
    public interface IHttpClientService
    {
        RestClient NewInstance(string jwtToken);
    }
}
