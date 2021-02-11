using System;
using Newtonsoft.Json;

namespace DevToAPI.Models.Responses
{
    public sealed class ReadingList
    {
        [JsonProperty("type_of")]
        public string TypeOf { get; private set; } 

        [JsonProperty("id")]
        public int Id { get; private set; } 

        [JsonProperty("status")]
        public string Status { get; private set; } 

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; private set; } 

        [JsonProperty("article")]
        public Article Article { get; private set; } 
    }
}