using Newtonsoft.Json;

namespace DevToAPI.Models.Responses
{
    public sealed class FollowedTag
    {
        [JsonProperty("id")]
        public long Id { get; private set; } 
        
        [JsonProperty("name")]
        public string Name { get; private set; } 
        
        [JsonProperty("points")]
        public float Points { get; private set; } 
    }
}