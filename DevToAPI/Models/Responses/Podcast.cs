using Newtonsoft.Json;

namespace DevToAPI.Models.Responses
{
    public sealed class Podcast
    {
        [JsonProperty("title")]
        public string Title { get; private set; } 

        [JsonProperty("slug")]
        public string Slug { get; private set; } 

        [JsonProperty("image_url")]
        public string ImageUrl { get; private set; } 
    }
}