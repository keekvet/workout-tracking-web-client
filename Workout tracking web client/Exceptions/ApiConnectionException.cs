using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Workout_tracking_web_client.Exceptions
{
    public class ApiConnectionException : Exception
    {
        public ApiConnectionException()
        {
        }

        public ApiConnectionException(string message) : base(message)
        {
        }

        public ApiConnectionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ApiConnectionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
