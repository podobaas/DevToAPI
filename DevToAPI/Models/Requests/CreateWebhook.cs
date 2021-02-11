using System.Collections.Generic;
using DevToAPI.Models.Enums;
using Newtonsoft.Json;

namespace DevToAPI.Models.Requests
{
    public sealed class CreateWebhook
    {
        [JsonProperty("target_url")]
        public string TargetUrl { get; set; } 

        [JsonProperty("source")]
        public string Source { get; set; } 

        [JsonProperty("events")]
        public List<WebhookEvent> Events { get; set; } 
    }
}