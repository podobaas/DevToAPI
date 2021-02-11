using System;
using System.Collections.Generic;
using DevToAPI.Models.Enums;
using Newtonsoft.Json;

namespace DevToAPI.Models.Responses
{
    public sealed class WebhookInfo
    {
        [JsonProperty("type_of")]
        public string TypeOf { get; private set; } 

        [JsonProperty("id")]
        public int Id { get; private set; } 

        [JsonProperty("source")]
        public string Source { get; private set; } 

        [JsonProperty("target_url")]
        public string TargetUrl { get; private set; } 

        [JsonProperty("events")]
        public IList<WebhookEvent> Events { get; private set; } 

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; private set; } 
        
        [JsonProperty("user")]
        public User User { get; private set; } 
    }
}