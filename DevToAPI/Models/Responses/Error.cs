using System.Net;
using Newtonsoft.Json;

namespace DevToAPI.Models.Responses
{
    public sealed class Error
    {
        [JsonProperty("error")]
        public string Message { get; private set; } 
        
        [JsonProperty("status")]
        public HttpStatusCode Status { get; private set; } 
    }
}