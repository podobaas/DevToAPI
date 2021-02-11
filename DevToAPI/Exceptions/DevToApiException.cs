using System;
using System.Net;
using System.Runtime.Serialization;
using DevToAPI.Models.Responses;

namespace DevToAPI.Exceptions
{
    [Serializable]
    public class DevToApiException : Exception
    {
        public HttpStatusCode StatusCode { get; }
        
        public DevToApiException(Error error):base(error.Message)
        {
            StatusCode = error.Status;
        }

        public DevToApiException(HttpStatusCode statusCode, string message):base(message)
        {
            StatusCode = statusCode;
        }
        
        protected DevToApiException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}